using Microsoft.EntityFrameworkCore;
using ProductoConBdd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductoConBdd.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DetalleProductoDto?> CrearProducto(CrearProductoDto dto)
        {
            Producto nuevo = new Producto
            {
                Nombre = dto.nombre,
                Precio = dto.precio,
                CreatedAt = DateTime.UtcNow.ToString("o"),
                UpdatedAt = DateTime.UtcNow.ToString("o")
            };

            _context.Productos.Add(nuevo);
            await _context.SaveChangesAsync();

            return new DetalleProductoDto
            {
                nombre = nuevo.Nombre,
                precio = nuevo.Precio,
                createdAt = nuevo.CreatedAt
            };
        }

        public async Task<List<DetalleProductoDto>> ListarProductos()
        {
            List<Producto> productos = await _context.Productos.ToListAsync();
            return productos.Select(p => new DetalleProductoDto
            {
                nombre = p.Nombre,
                precio = p.Precio,
                createdAt = p.CreatedAt
            }).ToList();
        }

        public async Task<DetalleProductoDto?> ObtenerProductoPorId(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return null;

            return new DetalleProductoDto
            {
                nombre = producto.Nombre,
                precio = producto.Precio,
                createdAt = producto.CreatedAt
            };
        }

        public async Task<DetalleProductoDto?> ModificarProducto(int id, CrearProductoDto dto)
        {
            Producto producto = await _context.Productos.FindAsync(id);
            if (producto == null) return null;

            producto.Nombre = dto.nombre;
            producto.Precio = dto.precio;
            producto.UpdatedAt = DateTime.UtcNow.ToString("o");

            await _context.SaveChangesAsync();

            return new DetalleProductoDto
            {
                nombre = producto.Nombre,
                precio = producto.Precio,
                createdAt = producto.CreatedAt
            };
        }

        public async Task<bool> EliminarProducto(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DetalleProductoDto>> ListarProductosPorPaginaAsync(int pagina, int elementosPorPagina)
        {
            if (pagina < 1) pagina = 1;
            if (elementosPorPagina < 1) elementosPorPagina = 3;

            int skip = (pagina - 1) * elementosPorPagina;

            var productos = await _context.Productos
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(elementosPorPagina)
                .Select(p => new DetalleProductoDto
                {
                    nombre = p.Nombre,
                    precio = p.Precio,
                    createdAt = p.CreatedAt
                })
                .ToListAsync();

            return productos;
        }
    }
}

