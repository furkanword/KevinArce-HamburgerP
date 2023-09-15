using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class HamburguesaRepository : GenericRepository<Hamburguesas>, IHamburguesasRepository
    {
        public HamburguesaRepository(DbAppContext context) : base(context)
        {
        }
    }
}