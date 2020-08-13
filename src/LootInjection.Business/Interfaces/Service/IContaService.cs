using System;
using System.Threading.Tasks;
using LootInjection.Business.Models;

namespace LootInjection.Business.Interfaces.Service
{
    public interface IContaService : IDisposable
    {
        Task Adicionar(Conta conta);
        Task Atualizar(Conta conta);
        Task Remover(Guid id);
    }
}