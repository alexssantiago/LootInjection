using System;
using System.Threading.Tasks;
using LootInjection.Business.Models;

namespace LootInjection.Business.Interfaces.Repository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorCliente(Guid clienteId);
    }
}