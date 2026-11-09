// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 1
// Archivo: Cuadrado.cs  ->  Clase HIJA de Figura
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================

namespace Ejercicio1_Figuras
{
    /// <summary>
    /// Cuadrado: hereda de la clase abstracta Figura (" : Figura ")
    /// y desarrolla sus dos métodos abstractos.
    /// </summary>
    public class Cuadrado : Figura
    {
        // Propiedad de solo lectura: medida de cada lado.
        public double Lado { get; }

        /// <summary>
        /// Constructor: recibe el lado y valida que sea positivo.
        /// </summary>
        /// <param name="lado">Medida del lado del cuadrado.</param>
        public Cuadrado(double lado)
        {
            // Validación: el lado debe ser mayor que cero.
            if (lado <= 0)
                throw new ArgumentException("El lado debe ser mayor que cero.");

            Lado = lado;
        }

        // Área del cuadrado = lado x lado
        public override double CalcularArea() => Lado * Lado;

        // Perímetro del cuadrado = 4 x lado
        public override double CalcularPerimetro() => 4 * Lado;
    }
}
