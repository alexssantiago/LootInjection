using LootInjection.Business.Interfaces.Notification;
using LootInjection.Business.Interfaces.Repository;
using LootInjection.Business.Interfaces.Service;
using LootInjection.Business.Models;
using LootInjection.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LootInjection.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              IEnderecoRepository enderecoRepository,
                              INotificator notificator) : base(notificator)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if(!ExecutarValidacao(new ClienteValidation(), cliente) || !!ExecutarValidacao(new EnderecoValidation(), cliente.Endereco)) return;

            if (_clienteRepository.Buscar(c => c.Cpf == cliente.Cpf).Result.Any())
            {
                Notificar("Já existe um cliente cadastrado com esse CPF.");
                return;
            }

            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            if (_clienteRepository.Buscar(c => c.Cpf == cliente.Cpf && c.Id != cliente.Id).Result.Any())
            {
                Notificar("Já existe um cliente cadastrado com esse CPF.");
                return;
            }

            await AtualizarEndereco(cliente.Endereco);

            await _clienteRepository.Atualizar(cliente);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            if (VerificarSePossuiContas(id))
            {
                Notificar("O Cliente possui contas cadastradas!");
                return;
            }

            var endereco = await _enderecoRepository.ObterEnderecoPorCliente(id);

            if (endereco != null) await _enderecoRepository.Remover(endereco.Id);

            await _clienteRepository.Remover(id);
        }

        private bool VerificarSePossuiContas(Guid idCliente)
        {
            return _clienteRepository.ObterClienteContas(idCliente).Result.Contas.Any();
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}