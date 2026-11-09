// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 2
// Archivo: Program.cs
// Tema: Trabajar con JSON usando Newtonsoft.Json
// Autor: Wilson Wu | Edad: 21
// Carrera: Ingeniería en Sistemas y Computación
// Situación: intercambiar los datos de una persona en formato JSON.
// ============================================================

// PASO 1: INSTALAR el paquete NuGet  ->  dotnet add package Newtonsoft.Json
// PASO 2: IMPORTAR el espacio de nombres de la biblioteca
using Newtonsoft.Json;

// Mensaje inicial (igual que en el ejemplo del enunciado)
Console.WriteLine("Hello, World!");

// PASO 3: Crear un objeto con datos.
// "new { ... }" crea un objeto anónimo: C# genera la clase automáticamente
// con las propiedades Nombre, Edad y Carrera.
var persona = new
{
    Nombre = "Wilson Wu",
    Edad = 21,
    Carrera = "Ingenieria en Sistemas y Computacion"
};

// PASO 4: Convertir (serializar) el objeto a una cadena JSON.
// JsonConvert.SerializeObject recorre las propiedades del objeto
// y produce: {"Nombre":"...","Edad":21,"Carrera":"..."}
string json = JsonConvert.SerializeObject(persona);

// Mostrar la cadena JSON en la consola
Console.WriteLine(json);

// Pausa para que la ventana no se cierre al ejecutar con F5
// (se omite si la entrada está redirigida, por ejemplo en pruebas automáticas).
Console.WriteLine("\nPresione cualquier tecla para salir...");
if (!Console.IsInputRedirected) Console.ReadKey();
