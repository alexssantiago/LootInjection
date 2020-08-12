using LootInjection.Business.Interfaces;
using LootInjection.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LootInjection.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Context context) : base(context) { }

        public async Task<IEnumerable<Cliente>> ObterClientesContas()
        {
            return await _dbSet.AsNoTracking().Include(c => c.Contas).ToListAsync();
        }

        public async Task<Cliente> ObterClienteContas(Guid id)
        {
            return await _dbSet.AsNoTracking().Include(c => c.Contas).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> ObterClienteEndereco(Guid id)
        {
            return await _dbSet.AsNoTracking().Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> ObterClienteContasEndereco(Guid id)
        {
            return await _dbSet.AsNoTracking().Include(c => c.Contas).Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}