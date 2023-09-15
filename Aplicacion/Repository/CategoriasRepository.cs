using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class CategoriasRepository : GenericRepository<Categorias>, ICategoriasRepository
    {
         private readonly DbAppContext _context;
        public CategoriasRepository(DbAppContext context) : base(context)
        {
        }
    }
}