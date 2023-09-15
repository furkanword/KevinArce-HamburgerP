
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class IngredientesRepository : GenericRepository<Ingredientes>, IIngredientesRepository
    {
        public IngredientesRepository(DbAppContext context) : base(context)
        {
        }
    }
}