namespace Dominio.Entities;

public class Chefs : BaseEntity
{
    public string Nombre { get; set; }
    public string Especialidad { get; set; }

    ICollection<Hamburguesas> Hamburguesas { get; set; }
}
