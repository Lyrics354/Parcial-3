// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: FrmRegistro.cs  ->  Formulario de registro de usuarios
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================
using Ejercicio3_LoginBCrypt.Datos;

namespace Ejercicio3_LoginBCrypt
{
    /// <summary>
    /// Pantalla de registro: valida los datos, genera el hash BCrypt de la
    /// contraseña y guarda el nuevo usuario en la base de datos.
    /// </summary>
    public partial class FrmRegistro : Form
    {
        // Objeto de acceso a datos (consultas a SQL Server y BCrypt).
        private readonly UsuarioDAO _dao = new UsuarioDAO();

        /// <summary>
        /// Usuario recién creado; FrmLogin lo lee para rellenar su campo de usuario.
        /// </summary>
        public string UsuarioRegistrado { get; private set; } = "";

        public FrmRegistro()
        {
            // Crea los controles definidos en FrmRegistro.Designer.cs
            InitializeComponent();
        }

        /// <summary>
        /// Botón "Generar hash y guardar".
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            // ---------- Validaciones ----------
            // 1. Ningún campo puede quedar vacío.
            if (nombre == "" || usuario == "" || password == "")
            {
                Aviso("Complete todos los campos.");
                return;
            }
            // 2. Longitud mínima de la contraseña.
            if (password.Length < 6)
            {
                Aviso("La contraseña debe tener al menos 6 caracteres.");
                return;
            }
            // 3. La contraseña y su confirmación deben coincidir.
            if (password != txtConfirmar.Text)
            {
                Aviso("Las contraseñas no coinciden.");
                return;
            }

            try
            {
                // 4. El nombre de usuario no puede repetirse.
                if (_dao.Existe(usuario))
                {
                    Aviso("Ese nombre de usuario ya existe.");
                    return;
                }

                // Se genera el hash con BCrypt.HashPassword() y se guarda en la BD.
                _dao.Registrar(usuario, nombre, password);

                // Se muestra el hash almacenado (nunca se guarda la contraseña en texto plano).
                txtHash.Text = _dao.Buscar(usuario)?.PasswordHash ?? "";

                MessageBox.Show("Usuario registrado correctamente.\nLa contraseña se guardó como hash BCrypt.",
                    "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Se devuelve el resultado al formulario de login y se cierra.
                UsuarioRegistrado = usuario;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                // Error típico: SQL Server apagado o base de datos no creada.
                MessageBox.Show("Error al guardar:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra un mensaje de advertencia de validación.
        /// </summary>
        private static void Aviso(string mensaje) =>
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
