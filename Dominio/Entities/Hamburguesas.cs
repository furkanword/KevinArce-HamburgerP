namespace Dominio.Entities;

public class Hamburguesas : BaseEntity
{
    public string Nombre { get; set; }
    public int Categoria_id { get; set;}
    public Categorias Categorias { get; set; }
    public  int Precio { get; set; }
    public int Chef_id { get; set; }
    public Chefs Chefs  { get; set; }
    public ICollection<Ingredientes> Ingredientes { get; set; } = new HashSet<Ingredientes>();
     public ICollection<Hamburguesa_ingredientes> HamburguesaIngredientes { get; set; }
     
}
