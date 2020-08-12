using LootInjection.Business.Interfaces;
using LootInjection.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LootInjection.Data.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(Context context) : base(context) { }

        public async Task<IEnumerable<Conta>> ObterContas()
        {
            return await _dbSet.AsNoTracking().OrderBy(c => c.Tipo).ToListAsync();
        }

        public async Task<IEnumerable<Conta>> ObterContasPorCliente(Guid clienteId)
        {
            return await Buscar(c => c.ClienteId == clienteId);
        }
    }
}