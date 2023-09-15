namespace Dominio.Entities;

public class Ingredientes : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Precio {get; set; }
    public int Stock {get; set; }
    public ICollection<Hamburguesa_ingredientes> HamburguesaIngredientes { get; set; }
    public ICollection<Hamburguesas> Hamburguesas { get; set; } = new HashSet<Hamburguesas>();
}
