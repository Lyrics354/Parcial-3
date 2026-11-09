// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 1
// Archivo: Program.cs  ->  Clase principal
// Autor: Wilson Wu | Edad: 21
// Carrera: Ingeniería en Sistemas y Computación
// Tema: clase abstracta, métodos abstractos, arreglo de tipo padre y polimorfismo
// ============================================================
using Ejercicio1_Figuras;

// Permite mostrar tildes y caracteres especiales en la consola.
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Encabezado del programa
Console.WriteLine("=== Parcial #3 - Ejercicio 1: Figuras (Polimorfismo) ===");
Console.WriteLine("Estudiante: Wilson Wu - Ingeniería en Sistemas y Computación\n");

// ------------------------------------------------------------
// ARREGLO UNIDIMENSIONAL (vector) de tipo PADRE: Figura[]
// Cada posición es una variable de tipo Figura, pero guarda
// un objeto de una clase HIJA (Rectangulo, Cuadrado o Triangulo).
// ------------------------------------------------------------
Figura[] figuras = new Figura[]
{
    new Rectangulo(8, 5),          // base 8, altura 5
    new Cuadrado(6),               // lado 6
    new Triangulo(3, 4, 5),        // triángulo rectángulo 3-4-5
    new Rectangulo(10.5, 2.5),     // base 10.5, altura 2.5
    new Cuadrado(3.2),             // lado 3.2
    new Triangulo(7, 7, 7)         // triángulo equilátero de lado 7
};

// Encabezado de la tabla de resultados
Console.WriteLine($"{"#",-3}{"Clase",-12} | {"Área",10} | {"Perímetro",10}");
Console.WriteLine(new string('-', 45));

// ------------------------------------------------------------
// RECORRIDO POLIMÓRFICO
// Se trata cada objeto hijo a través de una variable del padre (Figura).
// Al llamar CalcularArea() y CalcularPerimetro(), C# ejecuta en tiempo
// de ejecución la versión de la clase hija correspondiente.
// ------------------------------------------------------------
for (int i = 0; i < figuras.Length; i++)
{
    Figura f = figuras[i]; // variable del PADRE apuntando a un objeto HIJO

    // GetType().Name muestra dinámicamente el nombre real de la clase.
    Console.WriteLine($"{i + 1,-3}{f.GetType().Name,-12} | {f.CalcularArea(),10:F2} | {f.CalcularPerimetro(),10:F2}");
}

Console.WriteLine(new string('-', 45));

// Segundo recorrido polimórfico (foreach) para sumar el área de todas las figuras.
double areaTotal = 0;
foreach (Figura f in figuras)
    areaTotal += f.CalcularArea();

Console.WriteLine($"Área total de todas las figuras: {areaTotal:F2}");

// Pausa para que la ventana no se cierre al ejecutar con F5
// (se omite si la entrada está redirigida, por ejemplo en pruebas automáticas).
Console.WriteLine("\nPresione cualquier tecla para salir...");
if (!Console.IsInputRedirected) Console.ReadKey();
