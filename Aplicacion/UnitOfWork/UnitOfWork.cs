

using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    CategoriasRepository _categorias;
    ChefsRepository _chefs;
    IngredientesRepository _ingredientes;
    HamburguesaRepository _hamburguesa;
    Hambuerguesa_IngredientesRepository _hambuerguesa_Ingredientes;

    
    private readonly DbAppContext _context;
    public UnitOfWork(DbAppContext context)
    {
        _context = context;
    }

    public ICategoriasRepository Categorias
    {
        get{
            if (_categorias is not null)
            {
                return _categorias;
            }
            return _categorias = new CategoriasRepository(_context);
        }
    }
    public IChefsRepository Chefs
    {
        get{
            if (_chefs is not null)
            {
                return _chefs;
            }
            return _chefs = new ChefsRepository(_context);
        }
    }
    public IIngredientesRepository Ingredientes
    {
        get{
            if (_ingredientes is not null)
            {
                return _ingredientes;
            }
            return _ingredientes = new IngredientesRepository(_context);
        }
    }
    public HamburguesaRepository Hamburguesa
    {
        get{
            if (_hamburguesa is not null)
            {
                return _hamburguesa;
            }
            return _hamburguesa = new HamburguesaRepository(_context);
        }
    }
    public Hambuerguesa_IngredientesRepository Hambuerguesa_Ingredientes
    {
        get{
            if (_hambuerguesa_Ingredientes is not null)
            {
                return _hambuerguesa_Ingredientes;
            }
            return _hambuerguesa_Ingredientes = new Hambuerguesa_IngredientesRepository(_context);
        }
    }

    IHambuerguesa_ingredientesRepository IUnitOfWork.Hambuerguesa_Ingredientes => throw new NotImplementedException();

    public IHamburguesasRepository Hamburguesas => throw new NotImplementedException();

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }

}