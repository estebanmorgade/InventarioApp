using InventarioApp.Models;
using InventarioApp.Services;
using InventarioApp.Factories;
using InventarioApp.Infrastructure;

var servicio = new InventarioService();
bool activo = true;

Console.WriteLine("**** Bienvenido al sistema de inventario ****");

while (activo)
{
    MostrarMenu();
    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            AgregarProducto();
            break;
        case "2":
            ListarProductos();
            break;
        case "3":
            BuscarProductoPorId();
            break;
        case "4":
            EliminarProducto();
            break;
        case "5":
            BuscarPorCategoria();
            break;
        case "6":
            MostrarResumen();
            break;
        case "7":
            MostrarStockBajo();
            break;
        case "8":
            MostrarEstadisticas();
            break;
        case "9":
            ExportarCsv();
            break;
        case "10":
            activo = false;
            Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
            break;
        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }
}


void MostrarMenu()
{
    Console.WriteLine("\nSeleccione una opción:");
    Console.WriteLine("1. Agregar producto");
    Console.WriteLine("2. Listar productos");
    Console.WriteLine("3. Buscar producto por ID");
    Console.WriteLine("4. Eliminar producto");
    Console.WriteLine("5. Buscar productos por categoría");
    Console.WriteLine("6. Mostrar resumen del inventario");
    Console.WriteLine("7. Mostrar productos con stock bajo");
    Console.WriteLine("8. Mostrar estadísticas de inventario");
    Console.WriteLine("9. Exportar inventario a CSV");
    Console.WriteLine("10. Salir");
}

void AgregarProducto()
{
    Console.WriteLine("\nIngrese el nombre del producto:");
    string nombre = Console.ReadLine() ?? "";

    Console.WriteLine("Ingrese el precio del producto:");
    decimal precio = decimal.Parse(Console.ReadLine() ?? "0");

    Console.WriteLine("Ingrese la cantidad del producto:");
    int cantidad = int.Parse(Console.ReadLine() ?? "0");

    Console.WriteLine("Seleccione la categoría del producto:");
    foreach (var categoria in Enum.GetValues(typeof(CategoriaProducto)))
    {
        Console.WriteLine($"{(int)categoria}. {categoria}");
    }
    CategoriaProducto categoriaSeleccionada = (CategoriaProducto)int.Parse(Console.ReadLine() ?? "0");

    servicio.AgregarProducto(nombre, precio, cantidad, categoriaSeleccionada);
    Console.WriteLine("Producto agregado exitosamente.");
}

void ListarProductos()
{
    var productos = servicio.ObtenerTodosLosProductos();
    
    if (!productos.Any())
    {
        Console.WriteLine("No hay productos en el inventario.");
        return;
    }

    Console.WriteLine("\n**** Lista de Productos ****");
    foreach (var producto in productos)
    {
        Console.WriteLine($"ID: {producto.Id} | {producto.Nombre} | Precio: ${producto.Precio} | Cantidad: {producto.Cantidad} | Total: ${producto.ValorTotal} | Categoría: {producto.Categoria}");
    }
}

void BuscarProductoPorId()
{
    Console.WriteLine("\nIngrese el ID del producto a buscar:");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var producto = servicio.ObtenerProductoPorId(id);
    if (producto != null)
    {
        Console.WriteLine($"ID: {producto.Id} | {producto.Nombre} | Precio: {producto.Precio} | Cantidad: {producto.Cantidad} | Total: ${producto.ValorTotal} | Categoría: {producto.Categoria}");
    }
    else
    {
        Console.WriteLine("\nProducto no encontrado.");
    }
}

void EliminarProducto()
{
    Console.WriteLine("\nIngrese el ID del producto a eliminar:");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var producto = servicio.ObtenerProductoPorId(id);
    if (producto != null)
    {
        servicio.EliminarProducto(id);
        Console.WriteLine("Producto eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine("Producto no encontrado.");
    }
}

void BuscarPorCategoria()
{
    Console.WriteLine("\nSeleccione la categoría del producto:");
    foreach (var categoria in Enum.GetValues(typeof(CategoriaProducto)))
    {
        Console.WriteLine($"{(int)categoria}. {categoria}");
    }
    CategoriaProducto categoriaSeleccionada = (CategoriaProducto)int.Parse(Console.ReadLine() ?? "0");

    var productos = servicio.BuscarPorCategoria(categoriaSeleccionada);
    
    if (!productos.Any())
    {
        Console.WriteLine("\nNo hay productos en esta categoría.");
        return;
    }

    Console.WriteLine($"\n**** Productos en la categoría {categoriaSeleccionada} ****");
    foreach (var producto in productos)
    {
        Console.WriteLine($"ID: {producto.Id} | {producto.Nombre} | Precio: {producto.Precio} | Cantidad: {producto.Cantidad} | Total: ${producto.ValorTotal}");
    }
}

void MostrarResumen()
{
    var resumen = servicio.GenerarResumen();
    Console.WriteLine("\n" + resumen);
}

void MostrarStockBajo()
{
    var reporte = servicio.ObtenerProductosBajoStock();

    foreach (var producto in reporte)
    {
        Console.WriteLine($"ID: {producto.Id} | {producto.Nombre} | Stock: {producto.Cantidad} | Precio: ${producto.Precio}");
    }
}

void MostrarEstadisticas()
{
    Console.WriteLine("\n**** Estadísticas del Inventario ****");
    Console.WriteLine($"Valor total del inventario: ${servicio.ObtenerValorTotalInventario()}");
    Console.WriteLine($"Precio promedio: ${servicio.ObtenerPrecioPromedio():F2}");

    var masCaro = servicio.ObtenerProductoMasCaro();
    if (masCaro != null)
    {
        Console.WriteLine($"Producto más caro: {masCaro.Nombre} (${masCaro.Precio})");
    }
}

void ExportarCsv()
{
    try
    {
        string csv = servicio.ExportarCsv();
        Console.WriteLine($"\n{csv}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al exportar el inventario: {ex.Message}");
    }
}