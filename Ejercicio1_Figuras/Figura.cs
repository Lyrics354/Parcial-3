// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 1
// Archivo: Figura.cs  ->  Clase abstracta (clase PADRE)
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// ============================================================

namespace Ejercicio1_Figuras
{
    /// <summary>
    /// Clase abstracta que actúa como molde obligatorio para todas las figuras.
    /// No se puede instanciar directamente (no existe "new Figura()");
    /// obliga a las clases hijas a implementar CalcularArea() y CalcularPerimetro().
    /// </summary>
    public abstract class Figura
    {
        /// <summary>
        /// Método abstracto: no tiene cuerpo aquí.
        /// Cada clase hija debe desarrollarlo con "override".
        /// </summary>
        /// <returns>El área de la figura.</returns>
        public abstract double CalcularArea();

        /// <summary>
        /// Método abstracto: no tiene cuerpo aquí.
        /// Cada clase hija debe desarrollarlo con "override".
        /// </summary>
        /// <returns>El perímetro de la figura.</returns>
        public abstract double CalcularPerimetro();

        /// <summary>
        /// Propiedad concreta compartida por todas las hijas.
        /// GetType().Name devuelve el nombre REAL de la clase del objeto
        /// en tiempo de ejecución (Rectangulo, Cuadrado o Triangulo).
        /// </summary>
        public string Nombre => GetType().Name;

        /// <summary>
        /// Devuelve una línea de texto con el nombre, el área y el perímetro.
        /// Llama a los métodos abstractos, que se resuelven de forma polimórfica.
        /// </summary>
        public override string ToString()
        {
            // {valor,10:F2} -> alinea a 10 espacios y muestra 2 decimales
            return $"{Nombre,-12} | Área: {CalcularArea(),10:F2} | Perímetro: {CalcularPerimetro(),10:F2}";
        }
    }
}
