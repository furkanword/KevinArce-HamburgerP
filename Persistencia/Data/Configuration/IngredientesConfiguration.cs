using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class IngredienteConfiguration : IEntityTypeConfiguration<Ingredientes>
    {
        public void Configure(EntityTypeBuilder<Ingredientes> builder)
        {
            builder.ToTable("ingrediente");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
            .IsRequired()
            .HasColumnName("IdIngrediente");

            builder.Property(r => r.Nombre)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("NombreIngrediente");

            builder.Property(r => r.Descripcion)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("DescripcionIngrediente");

            builder.Property(r => r.Precio)
            .IsRequired()
            .HasColumnName("PrecioIngrediente");

            builder.Property(r => r.Stock)
            .IsRequired()
            .HasColumnName("StockIngrediente");
        }
    }
}