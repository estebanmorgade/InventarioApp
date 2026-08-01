using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Factories;
using InventarioApp.Infrastructure;

Console.WriteLine("**** Bienvenido al sistema de inventario ****");

/*var repository = new InMemoryProductoRepository();
var almacenamiento = new JsonInvetarioStorage();
string ruta = "invetario_test.json";*/

var productos = new List<Producto>
{
    ProductoFactory.Crear("Laptop", 1500.00m, 10, CategoriaProducto.Electronica),
    ProductoFactory.Crear("Mouse", 25.00m, 50, CategoriaProducto.Electronica),
    ProductoFactory.Crear("Teclado", 45.00m, 30, CategoriaProducto.Electronica),
    ProductoFactory.Crear("Silla de oficina", 120.00m, 20, CategoriaProducto.Muebles),
    ProductoFactory.Crear("Escritorio", 250.00m, 15, CategoriaProducto.Muebles)
};

var generador = new GeneradorReportes(productos);

Console.WriteLine(generador.GenerarResumen());
Console.WriteLine("\n");

Console.WriteLine(generador.GenerarReporteStockBajo());
Console.WriteLine("\n");

Console.WriteLine(generador.GenerarTopProductos());
Console.WriteLine("\n");

Console.WriteLine(generador.ExportCsv());
Console.WriteLine("\n");

Console.WriteLine(generador.ExportarResumenJson());


/*
repository.Agregar(laptop);
repository.Agregar(mouse);
repository.Agregar(teclado);
repository.Agregar(silla);
repository.Agregar(escritorio);

Console.WriteLine($"Productos agregados al inventario: {repository.Cantidad}\n");

// Consultas basicas LINQ

var electronicos = repository.BuscarPorCategoria(CategoriaProducto.Electronica);
Console.WriteLine("Productos de electrónica:");
foreach (var producto in electronicos)
{
    Console.WriteLine($"- {producto.Nombre} : {producto.Precio:C}");
}

var conMouse = repository.BuscarPorNombre("mouse");

foreach (var producto in conMouse)
{
    Console.WriteLine($"{producto.Nombre}");
}

var nombres = repository.ObtenerNombres();
Console.WriteLine($"\nTodos los nombres de productos en el inventario: {string.Join(", ", nombres)}"); //se podria hacer con Foreach pero es mas facil con string.Join ya que solo queremos unir las cadenas en una sola separada por comas.

var hayStockBajo = repository.HayStockBajo();
Console.WriteLine($"\n¿Hay productos con stock bajo? {(hayStockBajo ? "Sí" : "No")}");


almacenamiento.CrearBackup(ruta);
almacenamiento.Guardar(repository.ObtenerTodos(), ruta);

Console.WriteLine("Invetario guardaro correctamente");

var productosCargardos = almacenamiento.Cargar(ruta);

Console.WriteLine("Inventario cargado correctamente");

foreach (var p in productosCargardos)
{
    Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}, Cantidad: {p.Cantidad}, Categoria: {p.Categoria}, Estado: {p.Estado}");
}
*/