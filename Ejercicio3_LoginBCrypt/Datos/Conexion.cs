// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: Datos/Conexion.cs  ->  Conexión a la base de datos
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================
using Microsoft.Data.SqlClient;   // Conector oficial de .NET para SQL Server

namespace Ejercicio3_LoginBCrypt.Datos
{
    /// <summary>
    /// Centraliza la cadena de conexión a SQL Server Express.
    /// Si su instancia tiene otro nombre, solo cambie "Server" aquí.
    /// </summary>
    public static class Conexion
    {
        // Server=.\SQLEXPRESS        -> instancia local de SQL Server Express
        // Database=Parcial3_Login    -> base de datos creada con BaseDatos/Parcial3_Login.sql
        // Trusted_Connection=True    -> autenticación de Windows (sin usuario ni clave en el código)
        // TrustServerCertificate=True-> acepta el certificado local del servidor
        public const string Cadena =
            @"Server=.\SQLEXPRESS;Database=Parcial3_Login;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// Crea una nueva conexión (cerrada). Quien la usa debe abrirla
        /// y liberarla con "using" para no dejar conexiones abiertas.
        /// </summary>
        public static SqlConnection Obtener() => new SqlConnection(Cadena);
    }
}
