// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 1
// Archivo: Rectangulo.cs  ->  Clase HIJA de Figura
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================

namespace Ejercicio1_Figuras
{
    /// <summary>
    /// Rectángulo: hereda de la clase abstracta Figura (" : Figura ")
    /// y desarrolla sus dos métodos abstractos.
    /// </summary>
    public class Rectangulo : Figura
    {
        // Propiedades de solo lectura: se asignan una vez en el constructor.
        public double Base { get; }
        public double Altura { get; }

        /// <summary>
        /// Constructor: recibe las medidas y valida que sean positivas.
        /// </summary>
        /// <param name="baseRect">Base del rectángulo.</param>
        /// <param name="altura">Altura del rectángulo.</param>
        public Rectangulo(double baseRect, double altura)
        {
            // Validación: no existen lados con medida cero o negativa.
            if (baseRect <= 0 || altura <= 0)
                throw new ArgumentException("La base y la altura deben ser mayores que cero.");

            Base = baseRect;
            Altura = altura;
        }

        // Área del rectángulo = base x altura
        public override double CalcularArea() => Base * Altura;

        // Perímetro del rectángulo = 2 x (base + altura)
        public override double CalcularPerimetro() => 2 * (Base + Altura);
    }
}
