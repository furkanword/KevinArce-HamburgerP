using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categorias>
    {
        public void Configure(EntityTypeBuilder<Categorias> builder)
        {
            builder.ToTable("categoria");


            builder.Property(r => r.Id)
            .HasColumnName("IdCategoria")
            .HasMaxLength(3)
            .IsRequired();

            builder.Property(r => r.Nombre)
            .HasMaxLength(100)
            .HasColumnName("Nombre")
            .IsRequired();

            builder.Property(r => r.Descripcion)
            .HasMaxLength(200)
            .HasColumnName("Descripcion")
            .IsRequired();
        }
    }
}