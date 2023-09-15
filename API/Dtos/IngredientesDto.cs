namespace API.Dtos;

public class IngredientesDto
{
    public int Ingrediente_Id {get; set;}
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Precio {get; set; }
    public int Stock {get; set; }
}
