
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

MostrarBanner();

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

int cantidadProductos = 0;
//decimal valorTotalInventario = 0.00m;
bool sistemaActivo = true;
//string nombreSistema = "Sistema de Gestión de Inventario";

Console.WriteLine("Estado del sistema");
//Console.WriteLine($"Nombre: {nombreSistema}");
Console.WriteLine($"Productos registrados: {cantidadProductos}");
//Console.WriteLine($"Valor total del inventario: {valorTotalInventario:N2}");
Console.WriteLine($"Sistema activo: {(sistemaActivo ? "Sí" : "No")}");

Console.WriteLine("Comandos: listar, agregar, buscar, salir");
Console.WriteLine();

while (sistemaActivo)
{
    Console.Write("Inventario: ");
    string? entrada = Console.ReadLine();

    //Aplicamos el manejo seguro
    string comando = string.IsNullOrEmpty(entrada) ? "salir" : entrada.Trim().ToLower();
    switch (comando)
    {
        case "salir":
            Console.WriteLine("Saliendo del programa...");
            sistemaActivo = false;
            break;

        case "listar":
            Console.WriteLine($"Productos de inventario: {cantidadProductos}");
            break;

        case "":
            break;

        
        default:
            Console.WriteLine($"Comando '{comando}' desconocido");
            Console.WriteLine("Comandos disponibles: listar, agregar, buscar, salir");
            break;
    }
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
