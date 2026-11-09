// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 1
// Archivo: Triangulo.cs  ->  Clase HIJA de Figura
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================

namespace Ejercicio1_Figuras
{
    /// <summary>
    /// Triángulo definido por sus tres lados: hereda de la clase abstracta Figura
    /// y desarrolla sus dos métodos abstractos.
    /// </summary>
    public class Triangulo : Figura
    {
        // Propiedades de solo lectura: medida de cada uno de los tres lados.
        public double LadoA { get; }
        public double LadoB { get; }
        public double LadoC { get; }

        /// <summary>
        /// Constructor: recibe los tres lados y valida que formen un triángulo.
        /// </summary>
        public Triangulo(double ladoA, double ladoB, double ladoC)
        {
            // Validación 1: todos los lados deben ser positivos.
            if (ladoA <= 0 || ladoB <= 0 || ladoC <= 0)
                throw new ArgumentException("Los lados deben ser mayores que cero.");

            // Validación 2: desigualdad triangular
            // (la suma de dos lados siempre debe ser mayor que el tercero).
            if (ladoA + ladoB <= ladoC || ladoA + ladoC <= ladoB || ladoB + ladoC <= ladoA)
                throw new ArgumentException("Los lados no forman un triángulo válido.");

            LadoA = ladoA;
            LadoB = ladoB;
            LadoC = ladoC;
        }

        /// <summary>
        /// Área con la fórmula de Herón:
        /// s = semiperímetro;  Área = raíz( s(s-a)(s-b)(s-c) )
        /// </summary>
        public override double CalcularArea()
        {
            double s = CalcularPerimetro() / 2;   // semiperímetro
            return Math.Sqrt(s * (s - LadoA) * (s - LadoB) * (s - LadoC));
        }

        // Perímetro del triángulo = suma de sus tres lados
        public override double CalcularPerimetro() => LadoA + LadoB + LadoC;
    }
}
