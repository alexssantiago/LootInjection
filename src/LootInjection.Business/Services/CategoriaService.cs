using LootInjection.Business.Interfaces;
using LootInjection.Business.Interfaces.Notification;
using LootInjection.Business.Interfaces.Service;
using LootInjection.Business.Models;
using System;
using System.Threading.Tasks;
using LootInjection.Business.Interfaces.Repository;
using LootInjection.Business.Models.Validations;

namespace LootInjection.Business.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                INotificator notificator) : base(notificator)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task Remover(Guid id)
        {
            await _categoriaRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}