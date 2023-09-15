namespace Dominio.Entities;

public class Hamburguesa_ingredientes :  BaseEntity
{
    public int Hamburguesa_id { get; set; }
    public Hamburguesas Hamburguesas { get; set; }
    public int Ingrediente_Id { get; set; }
    public Ingredientes Ingredientes { get; set; }
}
