using Microsoft.AspNetCore.Mvc;
using ProductoConBdd.Services;
using System.Threading.Tasks;

namespace ProductoConBdd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProductoDto productoDto)
        {
            var resultado = await _productoService.CrearProducto(productoDto);

            if (resultado == null)
                return BadRequest("No se pudo crear el producto.");

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var productos = await _productoService.ListarProductos();
            return Ok(productos);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var producto = await _productoService.ObtenerProductoPorId(id);

            if (producto == null)
                return NotFound($"No se encontró producto con ID {id}");

            return Ok(producto);
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] CrearProductoDto productoDto)
        {
            var resultado = await _productoService.ModificarProducto(id, productoDto);

            if (resultado == null)
                return NotFound($"No se pudo modificar el producto con ID {id}");

            return Ok(resultado);
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _productoService.EliminarProducto(id);

            if (!eliminado)
                return NotFound($"No se encontró producto con ID {id} para borrar.");

            return Ok($"Producto con ID {id} eliminado correctamente.");
        }

  
        [HttpGet("paginado")]
        public async Task<IActionResult> ListarPaginado(int pagina = 1, int elementosPorPagina = 5)
        {
            var paginado = await _productoService.ListarProductosPorPaginaAsync(pagina, elementosPorPagina);
            return Ok(paginado);
        }
    }
}
