using InventarioApp.Models;

namespace InventarioApp.Repositories;

/// <summary>
/// Contrato para almacenamiento de productos
/// Defina las operaciones basicas CRUD
/// </summary>

public interface IProductoRepository
{
    /// <summary>
    /// Agrega un producto al repositorio
    /// </summary>
    /// <param name="producto">Producto a agregar</param>
    void Agregar(Producto producto);

    /// <summary>
    /// Obtiene todos los productos del repositorio
    /// </summary>
    /// <returns>Lista de productos</returns>
    IEnumerable<Producto> ObtenerTodos();

    /// <summary>
    /// Busca un producto por su ID
    /// </summary>
    /// <param name="id">ID del producto a buscar</param>
    /// <returns>Producto encontrado o null si no existe</returns>
    Producto? BuscarPorId(int id);

    /// <summary>
    /// Actualiza un producto existente en el repositorio
    /// </summary>
    /// <param name="producto">Producto con los datos actualizados</param>
    /// <returns>true si se actualizó correctamente, false si no se encontró el producto</returns>
    bool Actualizar(Producto producto);

    /// <summary>
    /// Elimina un producto del repositorio por su ID
    /// </summary>
    /// <param name="id">ID del producto a eliminar</param>
    /// <returns>true si se eliminó correctamente, false si no se encontró el producto</returns>
    bool Eliminar(int id);

    /// <summary>
    /// Cantidad de productos en el repositorio
    /// </summary>
    int Cantidad { get; }
}