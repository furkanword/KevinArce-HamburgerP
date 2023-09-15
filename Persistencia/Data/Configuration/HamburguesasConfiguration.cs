using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class HamburguesaConfiguration : IEntityTypeConfiguration<Hamburguesas>
    {
        public void Configure(EntityTypeBuilder<Hamburguesas> builder)
        {
            builder.ToTable("hamburguesa");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
            .IsRequired()
            .HasColumnName("IdHamburguesa");

            builder.Property(r => r.Nombre)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("NombreHamburguesa");

            builder.Property(r => r.Precio)
            .IsRequired()
            .HasColumnName("PrecioHamburguesa");

            builder
            .HasMany(r => r.Ingredientes)
            .WithMany(p => p.Hamburguesas)
            .UsingEntity<Hamburguesa_ingredientes>(

                j => j
                .HasOne(pt => pt.Ingredientes)
                .WithMany(t => t.HamburguesaIngredientes)
                .HasForeignKey(ut => ut.Ingrediente_Id),

                j => j
                .HasOne(et => et.Hamburguesas)
                .WithMany(e => e.HamburguesaIngredientes)
                .HasForeignKey(te => te.Hamburguesa_id),

                j =>
                {
                    j.ToTable("hamburguesa_ingrediente");
                    j.HasKey(t => new{t.Hamburguesa_id, t.Ingrediente_Id});
                }
            );
        }
    }
}