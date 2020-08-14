using LootInjection.Business.Interfaces;
using LootInjection.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LootInjection.Business.Interfaces.Repository;

namespace LootInjection.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(Context context) : base(context) { }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _dbSet.AsNoTracking().OrderBy(c => c.Descricao).ToListAsync();
        }
    }
}