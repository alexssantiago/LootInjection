using AutoMapper;
using LootInjection.Business.Interfaces.Notification;
using LootInjection.Business.Interfaces.Repository;
using LootInjection.Business.Interfaces.Service;
using LootInjection.Business.Models;
using LootInjection.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LootInjection.WebApp.MVC.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        private readonly IMapper _mapper;

        public ClienteController(INotificator notificator,
                                 IClienteRepository clienteRepository,
                                 IClienteService clienteService,
                                 IMapper mapper) : base(notificator)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [Route("meu-cadastro/{id:guid}")]
        public async Task<IActionResult> Cadastro(Guid id)
        {
            var clienteViewModel = await ObterClienteContasEndereco(id);

            if (clienteViewModel == null) return NotFound();

            return View(clienteViewModel);
        }

        [HttpPost]
        [Route("meu-cadastro/{id:guid}")]
        public async Task<IActionResult> Cadastro(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

            if (!OperacaoValida) return View(await ObterClienteContasEndereco(id));

            TempData["Sucesso"] = "Cadastro atualizado com sucesso!";

            return RedirectToAction("Cadastro", new { id });
        }

        private async Task<ClienteViewModel> ObterClienteContasEndereco(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteContasEndereco(id));
        }
    }
}
