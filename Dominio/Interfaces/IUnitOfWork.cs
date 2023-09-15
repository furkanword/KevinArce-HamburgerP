

namespace Dominio.Interfaces{
    public interface IUnitOfWork
    {
        ICategoriasRepository Categorias { get; }
        IChefsRepository Chefs    { get; }
        IHambuerguesa_ingredientesRepository Hambuerguesa_Ingredientes { get; }
        IIngredientesRepository Ingredientes { get; }
        IHamburguesasRepository Hamburguesas { get; }
        Task<int> SaveAsync();
    }
}

    

