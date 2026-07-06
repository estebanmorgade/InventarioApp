
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

Console.WriteLine("*****Bienvenido al sistema de gestión de inventario*****");
Console.WriteLine();
Console.WriteLine($"Versión: {version}");
Console.WriteLine($"Plataforma: {Environment.OSVersion}");
Console.WriteLine($".Net Version: {Environment.Version}");
Console.WriteLine("Creamos carpeta src/");
