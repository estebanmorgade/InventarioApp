using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Infrastructure;
using InventarioApp.Factories;

namespace InventarioApp.Services;

public class InventarioService
{
    private readonly InMemoryProductoRepository _repository;
    private readonly JsonInvetarioStorage _storage;
    private readonly string _rutaInventario;

    public InventarioService(string rutaInventario = "inventario.json")
    {
        _repository = new InMemoryProductoRepository();
        _storage = new JsonInvetarioStorage();
        _rutaInventario = rutaInventario;

        CargarInventario();
    }

    private void CargarInventario()
    {
        if (File.Exists(_rutaInventario))
        {
            var productos = _storage.Cargar(_rutaInventario);
            foreach (var producto in productos)
            {
                _repository.Agregar(producto);
            }
        }
    }

    public void AgregarProducto(string nombre, decimal precio, int cantidad, CategoriaProducto categoria)
    {
        var producto = ProductoFactory.Crear(nombre, precio, cantidad, categoria);
        _repository.Agregar(producto);
        _Persistir();
    }

    public IEnumerable<Producto> ObtenerTodosLosProductos()
    {
        return _repository.ObtenerTodos();
    }

    public Producto? ObtenerProductoPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }

    public void ActualizarProducto(int id, string nombre, decimal precio, int cantidad, CategoriaProducto categoria)
    {
        var producto = _repository.BuscarPorId(id);
        if (producto != null)
        {
            producto.Nombre = nombre;
            producto.Precio = precio;
            producto.Cantidad = cantidad;
            producto.Categoria = categoria;
            _repository.Actualizar(producto);
            _Persistir();
        }
    }

    public void EliminarProducto(int id)
    {
        _repository.Eliminar(id);
        _Persistir();
    }

    public IEnumerable<Producto> BuscarPorCategoria(CategoriaProducto categoria)
    {
        return _repository.BuscarPorCategoria(categoria);
    }

    public IEnumerable<Producto> BuscarPorNombre(string nombre)
    {
        return _repository.BuscarPorNombre(nombre);
    }

    public IEnumerable<Producto> ObtenerProductosBajoStock(int minimo = 5)
    {
        return _repository.ObtenerStockBajo(minimo);
    }

    public decimal ObtenerValorTotalInventario()
    {
        return _repository.ValorTotalInventario();
    }

    public decimal ObtenerPrecioPromedio()
    {
        return _repository.PrecioPromedio();
    }

    public Producto? ObtenerProductoMasCaro()
    {
        return _repository.ProductoMasCaro();
    }

    // Metodos reportes

    public string GenerarResumen()
    {
        var generador = new GeneradorReportes(_repository.ObtenerTodos());
        return generador.GenerarResumen();
    }

    public string GenerarReporteStockBajo(int minimo = 5)
    {
        var generador = new GeneradorReportes(_repository.ObtenerTodos());
        return generador.GenerarReporteStockBajo(minimo);
    }

    public string GenerarTopProductos(int cantidad = 5)
    {
        var generador = new GeneradorReportes(_repository.ObtenerTodos());
        return generador.GenerarTopProductos(cantidad);
    }

    public string ExportarCsv()
    {
        var generador = new GeneradorReportes(_repository.ObtenerTodos());
        return generador.ExportCsv();
    }

    private void _Persistir()
    {
        _storage.CrearBackup(_rutaInventario);
        var productos = _repository.ObtenerTodos().ToList();
        _storage.Guardar(productos, _rutaInventario);
    }
}