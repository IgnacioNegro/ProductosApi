using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductoConBdd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }


}