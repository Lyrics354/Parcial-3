// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: Datos/UsuarioDAO.cs  ->  Acceso a datos y lógica de BCrypt
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================
using System.Data;                // SqlDbType y DataTable
using Microsoft.Data.SqlClient;   // SqlCommand, SqlDataAdapter

namespace Ejercicio3_LoginBCrypt.Datos
{
    /// <summary>
    /// Entidad que representa una fila de la tabla Usuarios.
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }                          // Llave primaria
        public string NombreUsuario { get; set; } = "";      // Usuario para iniciar sesión
        public string NombreCompleto { get; set; } = "";     // Nombre que se muestra al entrar
        public string PasswordHash { get; set; } = "";       // Hash BCrypt (nunca la clave original)
    }

    /// <summary>
    /// DAO (Data Access Object): registro de usuarios, validación con BCrypt
    /// y bitácora de intentos de inicio de sesión.
    /// Todas las consultas usan parámetros (@u, @n, ...) para evitar inyección SQL.
    /// </summary>
    public class UsuarioDAO
    {
        // Factor de trabajo (costo) de BCrypt: 2^11 = 2048 rondas.
        // Mientras más alto, más lento y más difícil de atacar por fuerza bruta.
        private const int WorkFactor = 11;

        /// <summary>
        /// GENERAR EL HASH: crea el hash BCrypt de la contraseña y guarda el usuario en la BD.
        /// </summary>
        public void Registrar(string nombreUsuario, string nombreCompleto, string password)
        {
            // BCrypt genera automáticamente una sal aleatoria y la incluye dentro del hash.
            // Resultado: "$2a$11$" + 22 caracteres de sal + 31 caracteres de hash (60 en total).
            string hash = BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);

            // "using" cierra la conexión y el comando automáticamente al terminar.
            using var cn = Conexion.Obtener();
            using var cmd = new SqlCommand(
                "INSERT INTO Usuarios (NombreUsuario, NombreCompleto, PasswordHash) VALUES (@u, @n, @h)", cn);

            // Parámetros tipados: el valor nunca se concatena al texto SQL.
            cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = nombreUsuario;
            cmd.Parameters.Add("@n", SqlDbType.NVarChar, 100).Value = nombreCompleto;
            cmd.Parameters.Add("@h", SqlDbType.NVarChar, 100).Value = hash;

            cn.Open();
            cmd.ExecuteNonQuery();   // Ejecuta el INSERT
        }

        /// <summary>
        /// Indica si ya existe un usuario con ese nombre (para no duplicarlo).
        /// </summary>
        public bool Existe(string nombreUsuario)
        {
            using var cn = Conexion.Obtener();
            using var cmd = new SqlCommand("SELECT COUNT(1) FROM Usuarios WHERE NombreUsuario = @u", cn);
            cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = nombreUsuario;
            cn.Open();

            // ExecuteScalar devuelve la primera columna de la primera fila (el conteo).
            return (int)cmd.ExecuteScalar() > 0;
        }

        /// <summary>
        /// Busca un usuario por su nombre de usuario. Devuelve null si no existe.
        /// </summary>
        public Usuario? Buscar(string nombreUsuario)
        {
            using var cn = Conexion.Obtener();
            using var cmd = new SqlCommand(
                "SELECT Id, NombreUsuario, NombreCompleto, PasswordHash FROM Usuarios WHERE NombreUsuario = @u", cn);
            cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = nombreUsuario;
            cn.Open();

            using var dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;   // No se encontró ninguna fila

            // Se arma el objeto Usuario con las columnas leídas.
            return new Usuario
            {
                Id = dr.GetInt32(0),
                NombreUsuario = dr.GetString(1),
                NombreCompleto = dr.GetString(2),
                PasswordHash = dr.GetString(3)
            };
        }

        /// <summary>
        /// VERIFICAR LA CONTRASEÑA: compara la clave escrita con el hash guardado
        /// usando BCrypt.Verify() y registra el intento (exitoso o fallido).
        /// Devuelve el usuario si el acceso es correcto, o null si falla.
        /// </summary>
        public Usuario? IniciarSesion(string nombreUsuario, string password)
        {
            // 1. Obtener el usuario (y su hash) desde la base de datos.
            Usuario? usuario = Buscar(nombreUsuario);

            // 2. BCrypt.Verify extrae la sal del hash guardado, vuelve a calcular
            //    el hash con la clave escrita y compara ambos resultados.
            bool valido = usuario != null && BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash);

            // 3. Texto descriptivo del resultado para la bitácora.
            string detalle = usuario == null ? "Usuario no existe"
                           : valido ? "Acceso concedido"
                           : "Contraseña incorrecta";

            // 4. Guardar el intento en la tabla IntentosLogin.
            RegistrarIntento(nombreUsuario, usuario?.Id, valido, detalle);

            return valido ? usuario : null;
        }

        /// <summary>
        /// Guarda en la tabla IntentosLogin el usuario, la fecha, si fue exitoso,
        /// el detalle y el nombre del equipo, para un posible análisis posterior.
        /// </summary>
        public void RegistrarIntento(string nombreUsuario, int? usuarioId, bool exitoso, string detalle)
        {
            using var cn = Conexion.Obtener();
            using var cmd = new SqlCommand(
                @"INSERT INTO IntentosLogin (UsuarioId, NombreUsuario, Exitoso, Fecha, Detalle, Equipo)
                  VALUES (@id, @u, @e, GETDATE(), @d, @eq)", cn);

            // Si el usuario no existe, UsuarioId se guarda como NULL.
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = (object?)usuarioId ?? DBNull.Value;
            cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = nombreUsuario;
            cmd.Parameters.Add("@e", SqlDbType.Bit).Value = exitoso;                     // 1 = exitoso, 0 = fallido
            cmd.Parameters.Add("@d", SqlDbType.NVarChar, 100).Value = detalle;
            cmd.Parameters.Add("@eq", SqlDbType.NVarChar, 100).Value = Environment.MachineName;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Devuelve el historial de intentos (del más reciente al más antiguo)
        /// en un DataTable listo para mostrarse en un DataGridView.
        /// </summary>
        public DataTable ObtenerIntentos()
        {
            using var cn = Conexion.Obtener();

            // El CASE convierte el bit 1/0 en el texto "Exitoso"/"Fallido".
            using var da = new SqlDataAdapter(
                @"SELECT Id, NombreUsuario AS Usuario,
                         CASE WHEN Exitoso = 1 THEN 'Exitoso' ELSE 'Fallido' END AS Resultado,
                         Fecha, Detalle, Equipo
                  FROM IntentosLogin ORDER BY Fecha DESC", cn);

            var dt = new DataTable();
            da.Fill(dt);   // El adaptador abre y cierra la conexión por sí solo
            return dt;
        }

        /// <summary>
        /// Cuenta cuántos intentos exitosos y fallidos hay en total.
        /// </summary>
        public (int exitosos, int fallidos) ResumenIntentos()
        {
            using var cn = Conexion.Obtener();
            using var cmd = new SqlCommand(
                "SELECT ISNULL(SUM(CASE WHEN Exitoso=1 THEN 1 ELSE 0 END),0), ISNULL(SUM(CASE WHEN Exitoso=0 THEN 1 ELSE 0 END),0) FROM IntentosLogin", cn);
            cn.Open();

            using var dr = cmd.ExecuteReader();
            dr.Read();
            return (dr.GetInt32(0), dr.GetInt32(1));   // Tupla (exitosos, fallidos)
        }
    }
}
