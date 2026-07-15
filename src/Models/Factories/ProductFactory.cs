using InventarioApp.Models;

namespace InventarioApp.Factories;

public static class ProductFactory
{
    private static int _nextId = 1;
    public static Producto Crear(
        string nombre,
        decimal precio,
        int cantidad,
        CategoriaProducto categoria = CategoriaProducto.Otros)
    {
        // guard clauses to validate input parameters
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("Nombre requerido", nameof(nombre));

        if (precio < 0)
            throw new ArgumentOutOfRangeException("El precio no puede ser negativo", nameof(precio));

        if (cantidad < 0)
            throw new ArgumentOutOfRangeException("La cantidad no puede ser negativa", nameof(cantidad));

        return new Producto
        {
            Id = _nextId++,
            Nombre = nombre,
            Precio = precio,
            Cantidad = cantidad,
            Categoria = categoria,
            FechaRegistro = DateTime.Now
        };
    }

    public static Producto CrearConStock(string nombre, decimal precio, int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentOutOfRangeException("CrearConStock requiere cantidad > 0", nameof(cantidad));

        return Crear(nombre, precio, cantidad);
    }
}