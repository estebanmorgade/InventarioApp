using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Factories;

Console.WriteLine("**** Bienvenido al sistema de inventario ****");

var repository = new InMemoryProductoRepository();

var laptop = ProductoFactory.Crear("Laptop", 1500.00m, 10, CategoriaProducto.Electronica);
var mouse = ProductoFactory.Crear("Mouse", 25.00m, 50, CategoriaProducto.Electronica);
var teclado = ProductoFactory.Crear("Teclado", 45.00m, 30, CategoriaProducto.Electronica);
var silla = ProductoFactory.Crear("Silla de oficina", 120.00m, 20, CategoriaProducto.Muebles);
var escritorio = ProductoFactory.Crear("Escritorio", 250.00m, 15, CategoriaProducto.Muebles);

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