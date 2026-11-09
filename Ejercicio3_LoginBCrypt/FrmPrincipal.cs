// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: FrmPrincipal.cs  ->  Menú principal (después del login)
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================
using Ejercicio3_LoginBCrypt.Datos;

namespace Ejercicio3_LoginBCrypt
{
    /// <summary>
    /// Pantalla que se abre tras un acceso exitoso: muestra el nombre del usuario
    /// y el historial de intentos de inicio de sesión para su análisis.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        // Usuario que inició sesión (lo envía FrmLogin).
        private readonly Usuario _usuario;

        // Objeto de acceso a datos para consultar la bitácora de intentos.
        private readonly UsuarioDAO _dao = new UsuarioDAO();

        /// <summary>
        /// Constructor sin parámetros: solo lo usa el diseñador de Visual Studio
        /// para poder dibujar el formulario en modo diseño.
        /// </summary>
        public FrmPrincipal() : this(new Usuario { NombreCompleto = "(diseño)", NombreUsuario = "(diseño)" }) { }

        /// <summary>
        /// Constructor real: recibe el usuario autenticado.
        /// </summary>
        public FrmPrincipal(Usuario usuario)
        {
            // Crea los controles definidos en FrmPrincipal.Designer.cs
            InitializeComponent();
            _usuario = usuario;
        }

        /// <summary>
        /// Evento Load: se ejecuta al abrir el formulario.
        /// </summary>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Al tener acceso exitoso se indica el nombre del usuario.
            lblBienvenida.Text = $"¡Bienvenido, {_usuario.NombreCompleto}!";
            lblUsuario.Text = $"Usuario: {_usuario.NombreUsuario}    |    Acceso: {DateTime.Now:dd/MM/yyyy hh:mm tt}";

            // Se carga la tabla de intentos.
            CargarIntentos();
        }

        /// <summary>
        /// Consulta la tabla IntentosLogin y la muestra en el DataGridView,
        /// junto con el total de intentos exitosos y fallidos.
        /// </summary>
        private void CargarIntentos()
        {
            try
            {
                dgvIntentos.DataSource = _dao.ObtenerIntentos();

                // Deconstrucción de la tupla devuelta por ResumenIntentos().
                var (exitosos, fallidos) = _dao.ResumenIntentos();
                lblResumen.Text = $"Intentos exitosos: {exitosos}  |  Intentos fallidos: {fallidos}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el historial:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón "Actualizar": vuelve a consultar el historial.
        private void btnActualizar_Click(object sender, EventArgs e) => CargarIntentos();

        // Botón "Cerrar sesión": cierra esta ventana y FrmLogin se vuelve a mostrar.
        private void btnCerrarSesion_Click(object sender, EventArgs e) => Close();
    }
}
