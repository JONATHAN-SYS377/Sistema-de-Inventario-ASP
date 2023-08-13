using Microsoft.EntityFrameworkCore;
using Sistema_de_Inventario_ASP.Models;

namespace Sistema_de_Inventario_ASP.Datos
{
    public class ApplicationDbContext:DbContext
    {
        // Contructor de la clase
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estado> Estado { get; set; }
    }
}
