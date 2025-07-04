using Microsoft.EntityFrameworkCore;
using web_service_calculadora_despliegue.Models;

namespace web_service_calculadora_despliegue.Data
{
    public class OperacionesDbContext : DbContext
    {
        public OperacionesDbContext(DbContextOptions<OperacionesDbContext> options)
            : base(options) { }

        public DbSet<Operacion> Operaciones => Set<Operacion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operacion>(entity =>
            {
                // Especificar el nombre de la tabla en la base de datos
                entity.ToTable("operaciones");

                // Configurar las propiedades de la entidad con los nombres de columnas correspondientes en la base de datos
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Num1).HasColumnName("num1");
                entity.Property(e => e.Num2).HasColumnName("num2");
                entity.Property(e => e.TipoOperacion).HasColumnName("tipo_operacion");
                entity.Property(e => e.Resultado).HasColumnName("resultado");
            });
        }
    }
}

