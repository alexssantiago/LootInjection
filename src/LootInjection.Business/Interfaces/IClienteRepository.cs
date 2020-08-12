using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LootInjection.Business.Models;

namespace LootInjection.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> ObterClientesContas();
        Task<Cliente> ObterClienteContas(Guid id);
        Task<Cliente> ObterClienteContasEndereco(Guid id);
        Task<Cliente> ObterClienteEndereco(Guid id);
    }
}