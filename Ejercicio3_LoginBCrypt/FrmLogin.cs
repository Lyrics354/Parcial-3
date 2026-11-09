// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: FrmLogin.cs  ->  Formulario de inicio de sesión
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================
using Ejercicio3_LoginBCrypt.Datos;

namespace Ejercicio3_LoginBCrypt
{
    /// <summary>
    /// Pantalla de login: pide usuario y contraseña, los verifica con BCrypt
    /// y, si son correctos, abre el menú principal mostrando el nombre del usuario.
    /// </summary>
    public partial class FrmLogin : Form
    {
        // Objeto de acceso a datos (consultas a SQL Server y BCrypt).
        private readonly UsuarioDAO _dao = new UsuarioDAO();

        public FrmLogin()
        {
            // Crea los controles definidos en FrmLogin.Designer.cs
            InitializeComponent();
        }

        /// <summary>
        /// Botón "Ingresar": valida los campos e intenta iniciar sesión.
        /// </summary>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Trim() quita espacios al inicio y al final del usuario.
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            // Validación: ambos campos son obligatorios.
            if (usuario == "" || password == "")
            {
                MostrarEstado("Ingrese usuario y contraseña.", Color.DarkOrange);
                return;
            }

            try
            {
                // Busca el hash en la BD y lo compara con BCrypt.Verify();
                // el intento (exitoso o fallido) queda registrado en IntentosLogin.
                Usuario? u = _dao.IniciarSesion(usuario, password);

                // Acceso denegado: mensaje en rojo y se limpia la contraseña.
                if (u == null)
                {
                    MostrarEstado("Usuario o contraseña incorrectos.", Color.Firebrick);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // Acceso concedido: se indica el nombre del usuario.
                MessageBox.Show($"¡Bienvenido, {u.NombreCompleto}!", "Acceso concedido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Se limpia el login y se oculta mientras está abierto el menú principal.
                txtPassword.Clear();
                lblEstado.Text = "";
                Hide();
                using (var principal = new FrmPrincipal(u))
                {
                    principal.ShowDialog();   // Espera hasta que el usuario cierre sesión
                }

                // Al cerrar sesión se vuelve a mostrar el login.
                Show();
                txtUsuario.Focus();
            }
            catch (Exception ex)
            {
                // Error típico: SQL Server apagado o base de datos no creada.
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón "Registrar usuario": abre el formulario de registro.
        /// </summary>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistro();

            // Si el registro fue exitoso, se coloca el usuario nuevo en el login.
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                txtUsuario.Text = frm.UsuarioRegistrado;
                txtPassword.Focus();
                MostrarEstado("Usuario registrado. Inicie sesión.", Color.SeaGreen);
            }
        }

        /// <summary>
        /// Casilla "Mostrar contraseña": alterna entre ver la clave o los puntos.
        /// </summary>
        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkMostrar.Checked;
        }

        /// <summary>
        /// Muestra un mensaje de estado debajo de los botones con el color indicado.
        /// </summary>
        private void MostrarEstado(string texto, Color color)
        {
            lblEstado.ForeColor = color;
            lblEstado.Text = texto;
        }
    }
}
