using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Chefs> Chefs { get; set; }
        public DbSet<Hamburguesa_ingredientes> Hamburguesa_Ingredientes { get; set; }
        public DbSet<Hamburguesas> Hamburguesas { get; set; }
        public DbSet<Ingredientes> Ingredientes { get; set;}
    }
}