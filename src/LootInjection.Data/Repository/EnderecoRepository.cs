using LootInjection.Business.Interfaces;
using LootInjection.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using LootInjection.Business.Interfaces.Repository;

namespace LootInjection.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(Context context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorCliente(Guid clienteId)
        {
            return await _dbSet.AsNoTracking().Where(e => e.ClienteId == clienteId).FirstOrDefaultAsync();
        }
    }
}