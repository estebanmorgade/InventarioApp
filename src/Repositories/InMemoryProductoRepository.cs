using InventarioApp.Models;

namespace InventarioApp.Repositories;

public class InMemoryProductoRepository : IProductoRepository
{
    private readonly List<Producto> _productos = new();

    private int _nextId = 1;

    public void Agregar(Producto producto)
    {
        producto.Id = _nextId++;
        _productos.Add(producto);
    }

    public IEnumerable<Producto> ObtenerTodos()
    {
        return _productos;
    }

    public Producto? BuscarPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public bool Actualizar(Producto producto)
    {
        var existingProducto = BuscarPorId(producto.Id);
        if (existingProducto == null) return false;

        existingProducto.Nombre = producto.Nombre;
        existingProducto.Precio = producto.Precio;
        existingProducto.Cantidad = producto.Cantidad;
        existingProducto.Categoria = producto.Categoria;
        existingProducto.Estado = producto.Estado;

        return true;
    }

    public bool Eliminar(int id)
    {
        var producto = BuscarPorId(id);
        if (producto == null) return false;

        _productos.Remove(producto);
        return true;
    }

    public int Cantidad => _productos.Count;

    public IEnumerable<Producto> BuscarPorCategoria(CategoriaProducto categoria)
    {
        return _productos.Where(p => p.Categoria == categoria);
    }

    public IEnumerable<Producto> BuscarPorNombre(string nombre)
    {
        return _productos.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Producto> BuscarPorRangoPrecio(decimal precioMinimo, decimal precioMaximo)
    {
        return _productos.Where(p => p.Precio >= precioMinimo && p.Precio <= precioMaximo);
    }

    // ============ SELECT y ANY ============
    public IEnumerable<string> ObtenerNombres()
    {
        return _productos.Select(p => p.Nombre);
    }

    public bool HayStockBajo()
    {
        return _productos.Any(p => p.Cantidad < 5);
    }

    // ============ ORDER BY ============
    public IEnumerable<Producto> ObtenerOrdenadoPorPrecio(bool ascendente = true, int cantidad = 0)
    {
        var query = ascendente ? _productos.OrderBy(p => p.Precio) : _productos.OrderByDescending(p => p.Precio);
        return cantidad > 0 ? query.Take(cantidad) : query;
    }

    // ============ GROUP BY y conversion a Dictionary ============

    public IEnumerable<IGrouping<CategoriaProducto, Producto>> AgruparPorCategoria()
    {
        return _productos.GroupBy(p => p.Categoria);
    }

    public Dictionary<CategoriaProducto, int> ContarPorCategoria()
    {
        return _productos //List<Producto>
        .GroupBy(p => p.Categoria) //IEnumerable<IGrouping<CategoriaProducto, Producto>>
        .ToDictionary(g => g.Key, g => g.Count());
    }

    // Agregaciones con SUM, AVERAGE, MAXBY

    public decimal ValorTotalInventario()
    {
        return _productos.Sum(p => p.ValorTotal);
    }

    public decimal PrecioPromedio()
    {
        if(_productos.Count == 0) return 0;
        return _productos.Average(p => p.Precio);
    }

    public Producto? ProductoMasCaro()
    {
        return _productos.MaxBy(p => p.Precio);
    }

    public Dictionary<CategoriaProducto, decimal> ValorTotalPorCategoria()
    {
        return _productos //List<Producto>
            .GroupBy(p => p.Categoria) //IEnumerable<IGrouping<CategoriaProducto, Producto>>
            .ToDictionary(g => g.Key, g => g.Sum(p => p.ValorTotal));
    }

    public IEnumerable<Producto> ObtenerStockBajo(int cantidadMinima = 5)
    {
        return _productos.Where(p => p.Cantidad < cantidadMinima);
    }
}