using System;
using System.Threading.Tasks;
using LootInjection.Business.Interfaces;
using LootInjection.Business.Interfaces.Notification;
using LootInjection.Business.Interfaces.Service;
using LootInjection.Business.Models;
using LootInjection.Business.Models.Validations;

namespace LootInjection.Business.Services
{
    public class ContaService : BaseService, IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository,
                            INotificator notificator) : base(notificator)
        {
            _contaRepository = contaRepository;
        }

        public async Task Adicionar(Conta conta)
        {
            if (!ExecutarValidacao(new ContaValidation(), conta)) return;

            await _contaRepository.Adicionar(conta);
        }

        public async Task Atualizar(Conta conta)
        {
            if (!ExecutarValidacao(new ContaValidation(), conta)) return;

            await _contaRepository.Atualizar(conta);
        }

        public async Task Remover(Guid id)
        {
            await _contaRepository.Remover(id);
        }

        public void Dispose()
        {
            _contaRepository?.Dispose();
        }
    }
}