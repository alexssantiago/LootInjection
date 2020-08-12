using System.Collections.Generic;
using System.Threading.Tasks;
using LootInjection.Business.Models;

namespace LootInjection.Business.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> ObterCategorias();
    }
}