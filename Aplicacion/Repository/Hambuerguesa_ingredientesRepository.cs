using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class Hambuerguesa_IngredientesRepository : GenericRepository<Hamburguesa_ingredientes>, IHambuerguesa_ingredientesRepository
    {
        public Hambuerguesa_IngredientesRepository(DbAppContext context) : base(context)
        {
        }
    }
}