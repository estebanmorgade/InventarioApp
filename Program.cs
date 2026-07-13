
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

if(args.Length > 0)
{
    switch (args[0].ToLower())
    {
        case "--help":
        case "-h":
            MostrarAyuda();
            Environment.Exit(0);
            break;
        case "--version":
        case "-v":
            Console.WriteLine($"Versión: {version}");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine($"Comando desconocido: {args[0]}");
            MostrarAyuda();
            Environment.Exit(2);
            break;
    }
}

MostrarBanner();


Console.Write("Ingrese un comando (o 'salir' para terminar):");
string? entrada = Console.ReadLine(); //stdin

if (string.IsNullOrWhiteSpace(entrada) || entrada.ToLower() == "salir")
{
    Console.WriteLine("Saliendo del programa...");//stdout
    Environment.Exit(0);
}

//FUNCIONES

void MostrarBanner()
{
    Console.WriteLine("***************************************");
    Console.WriteLine("*  Sistema de Gestión de Inventario   *");
    Console.WriteLine("***************************************");
    Console.WriteLine($"Versión: {version}");
    Console.WriteLine($"Plataforma: {Environment.OSVersion}");
    Console.WriteLine($".Net Version: {Environment.Version}");
}
void MostrarAyuda()
{
    Console.WriteLine("Comandos disponibles:");
    Console.WriteLine("1. --help, -h  Muestra esta ayuda");
    Console.WriteLine("2. --version, -v Muestra la versión");
    Console.WriteLine();
    Console.WriteLine("EJEMPLOS:");
    Console.WriteLine("   dotnet run -- --help");
    Console.WriteLine("   dotnet run ----version");
}
