using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LootInjection.Business.Models;

namespace LootInjection.Business.Interfaces.Repository
{
    public interface IContaRepository : IRepository<Conta>
    {
        Task<IEnumerable<Conta>> ObterContas();
        Task<IEnumerable<Conta>> ObterContasPorCliente(Guid clienteId);
    }
}