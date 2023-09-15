namespace Dominio.Entities;

public class Categorias : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    ICollection<Hamburguesas> Hamburguesas  { get; set; }

}
