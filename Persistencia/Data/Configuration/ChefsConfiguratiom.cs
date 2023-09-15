using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class ChefConfiguration : IEntityTypeConfiguration<Chefs>
    {
        public void Configure(EntityTypeBuilder<Chefs> builder)
        {
            builder.ToTable("chef");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
            .HasColumnName("IdChef")
            .IsRequired();

            builder.Property(r => r.Nombre)
            .HasMaxLength(100)
            .HasColumnName("Nombre")
            .IsRequired();

            builder.Property(r => r.Especialidad)    
            .HasMaxLength(100)
            .HasColumnName("Especialidad")
            .IsRequired();
        }
    }
}