using ProductoConBdd;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductoService
{
    Task<DetalleProductoDto?> CrearProducto(CrearProductoDto dto);
    Task<List<DetalleProductoDto>> ListarProductos();
    Task<DetalleProductoDto?> ObtenerProductoPorId(int id);
    Task<DetalleProductoDto?> ModificarProducto(int id, CrearProductoDto dto);
    Task<bool> EliminarProducto(int id);
    Task<List<DetalleProductoDto>> ListarProductosPorPaginaAsync(int pagina, int elementosPorPagina);
}