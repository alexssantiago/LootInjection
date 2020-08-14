using AutoMapper;
using LootInjection.Business.Interfaces.Notification;
using LootInjection.Business.Interfaces.Repository;
using LootInjection.Business.Interfaces.Service;
using LootInjection.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LootInjection.Business.Models;

namespace LootInjection.WebApp.MVC.Controllers
{
    public class ContaController : BaseController
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContaService _contaService;

        private readonly IMapper _mapper;

        public ContaController(INotificator notificator,
            IContaRepository contaRepository,
            IContaService contaService,
            IMapper mapper) : base(notificator)
        {
            _contaRepository = contaRepository;
            _contaService = contaService;
            _mapper = mapper;
        }

        [Route("minhas-contas/{clienteId:guid}")]
        public async Task<IActionResult> Index(Guid clienteId)
        {
            var contasViewModel = await ObterContasPorCliente(clienteId);

            if (contasViewModel == null) return NotFound();

            return View(contasViewModel);
        }

        [Route("cadastro-conta/{clienteId:guid}")]
        public IActionResult Cadastrar(Guid clienteId)
        {
            return PartialView("_CadastroConta", new ContaViewModel() { ClienteId = clienteId });
        }

        [HttpPost]
        [Route("cadastro-conta/{clienteId:guid}")]
        public async Task<IActionResult> Cadastrar(ContaViewModel contaViewModel)
        {
            if (!ModelState.IsValid) return PartialView("_CadastroConta", contaViewModel);

            await _contaService.Adicionar(_mapper.Map<Conta>(contaViewModel));

            if (!OperacaoValida) return PartialView("_CadastroConta", contaViewModel);

            TempData["Sucesso"] = "Conta cadastrada com sucesso!";

            var url = Url.Action("ObterContas", "Conta", new { clienteId = contaViewModel.ClienteId });
            return Json(new { success = true, url });
        }

        [Route("obter-contas/{clienteId:guid}")]
        public async Task<IActionResult> ObterContas(Guid clienteId)
        {
            var contasViewModel = await ObterContasPorCliente(clienteId);

            if (contasViewModel == null) return NotFound();

            return PartialView("_ListaContas", contasViewModel);
        }

        private async Task<IEnumerable<ContaViewModel>> ObterContasPorCliente(Guid id)
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(await _contaRepository.ObterContasPorCliente(id));
        }
    }
}