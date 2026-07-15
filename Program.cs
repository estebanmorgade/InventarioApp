
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

/*if(args.Length > 0)
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
*/

//variables
int cantidadProductos = 0;
decimal valorTotalInventario = 0.00m;
bool sistemaActivo = true;

MostrarBanner();

bool continuar = true;

while (continuar)
{
    MostrarMenu();
    string comando = LeerEntrada("inventario");
    continuar = ProcesarComando(comando);
}

// ============ METODOS ============

bool ProcesarComando(string comando)
{
    switch (comando)
    {
        case "listar":
            ListarProductos();
            return true;
        case "agregar":
            AgregarProducto();
            return true;
        case "buscar":
            BuscarProducto();
            return true;
        case "salir":
            Console.WriteLine("Saliendo del programa...");
            return false;
        default:
            Console.WriteLine($"Comando '{comando}' no valido");
            return true;
    }
}

void ListarProductos()
{
    Console.WriteLine($"Total: {cantidadProductos} productos en el inventario");
    Console.WriteLine($"Valor total del inventario: {valorTotalInventario:C}");
}

void AgregarProducto()
{
    Console.WriteLine("Agregar producto (Modulo3)");
}

void BuscarProducto()
{
    Console.WriteLine("Buscar producto (Modulo4)");
}

string LeerEntrada(string prompt)
{
    string salida = "El prompt ingresado es: " + prompt;
    return salida;
}
// ============ FUNCIONES ============

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

void MostrarMenu()
{
    Console.WriteLine("\nMENU PRINCIPAL");
    Console.WriteLine("1. listar - Muestra la lista de productos");
    Console.WriteLine("2. agregar - Agrega un nuevo producto");
    Console.WriteLine("3. buscar - Busca un producto por nombre");
    Console.WriteLine("4. salir - Salir del programa");
}