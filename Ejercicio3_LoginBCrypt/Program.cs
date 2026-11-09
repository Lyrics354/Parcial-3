// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: Program.cs  ->  Punto de entrada de la aplicación
// Tema: Login con hash BCrypt (BCrypt.Net-Next) + SQL Server
// Autor: Wilson Wu | Edad: 21
// Carrera: Ingeniería en Sistemas y Computación
// ============================================================
namespace Ejercicio3_LoginBCrypt
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación de Windows Forms.
        /// [STAThread] es obligatorio en Windows Forms (modelo de hilo de la interfaz).
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Aplica la configuración por defecto: estilos visuales, fuente y DPI.
            ApplicationConfiguration.Initialize();

            // Abre el formulario de inicio de sesión como ventana principal.
            Application.Run(new FrmLogin());
        }
    }
}
