using FerrocarrilNCA.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FerrocarrilNCA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BaseOperativa> BaseOperativas => Set<BaseOperativa>();
        public DbSet<Empleado> Empleados => Set<Empleado>();
        public DbSet<Servicio> Servicios => Set<Servicio>();
        public DbSet<Sueldo> Sueldos => Set<Sueldo>();
        public DbSet<Categoria> Categorias => Set<Categoria>();

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(150);
            
            
        }

    }
}
