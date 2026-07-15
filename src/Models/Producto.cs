namespace InventarioApp.Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";

    public string Descripcion { get; set; } = "";
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

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

    public override string ToString()
        => $"[{Id}] {Nombre} - ${Precio:N2} X {Cantidad} = ${ValorTotal:N2}";
}