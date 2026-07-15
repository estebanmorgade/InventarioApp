namespace InventarioApp.Models;

public class Producto
{
    public int Id { get; set; }
    private string _nombre = "";
    private decimal _precio;
    private int _cantidad;

    public string Nombre
    {
        get => _nombre;
        set
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(Nombre));
                _nombre = value.Trim();
        }
    }

    public decimal Precio
    {
        get => _precio;
        set
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException("El precio del producto no puede ser negativo.", nameof(Precio));
                _precio = value;
        }
    }

    public int Cantidad
    {
        get => _cantidad;
        set
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException("La cantidad del producto no puede ser negativa.", nameof(Cantidad));
                _cantidad = value;
        }
    }

    public CategoriaProducto Categoria { get; set; }

    public EstadoProducto Estado { get; set; } = EstadoProducto.Activo;

    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    public decimal ValorTotal => Precio * Cantidad;

    /*public Producto(string nombre, decimal precio, int cantidad)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }*/
}