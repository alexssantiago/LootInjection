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

        [Route("obter-contas/{clienteId:guid}")]
        public async Task<IActionResult> ObterContas(Guid clienteId)
        {
            var contasViewModel = await ObterContasPorCliente(clienteId);

            if (contasViewModel == null) return NotFound();

            return PartialView("_ListaContas", contasViewModel);
        }

        [Route("cadastro-conta/{clienteId:guid}")]
        public IActionResult Cadastrar(Guid clienteId)
        {
            return PartialView("_Cadastro", new ContaViewModel() { ClienteId = clienteId });
        }

        [HttpPost]
        [Route("cadastro-conta/{clienteId:guid}")]
        public async Task<IActionResult> Cadastrar(ContaViewModel contaViewModel)
        {
            if (!ModelState.IsValid) return PartialView("_Cadastro", contaViewModel);

            await _contaService.Adicionar(_mapper.Map<Conta>(contaViewModel));

            if (!OperacaoValida) return PartialView("_Cadastro", contaViewModel);

            TempData["Sucesso"] = "Conta cadastrada com sucesso!";

            var url = Url.Action("ObterContas", "Conta", new { clienteId = contaViewModel.ClienteId });
            return Json(new { success = true, url });
        }

        [Route("atualizar-conta/{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var contaViewModel = await ObterConta(id);

            if (contaViewModel == null) return NotFound();

            return PartialView("_Edicao", contaViewModel);
        }

        [HttpPost]
        [Route("atualizar-conta/{id:guid}")]
        public async Task<IActionResult> Atualizar(ContaViewModel contaViewModel)
        {
            if (!ModelState.IsValid) return PartialView("_Edicao", contaViewModel);

            await _contaService.Atualizar(_mapper.Map<Conta>(contaViewModel));

            if (!OperacaoValida) return PartialView("_Edicao", contaViewModel);

            TempData["Sucesso"] = "Conta atualizada com sucesso!";

            var url = Url.Action("ObterContas", "Conta", new { clienteId = contaViewModel.ClienteId });
            return Json(new { success = true, url });
        }

        [Route("excluir-conta/{id:guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var contaViewModel = await ObterConta(id);

            if (contaViewModel == null) return NotFound();

            return View(contaViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        [Route("excluir-conta/{id:guid}")]
        public async Task<IActionResult> ExcluirConfirmado(Guid id)
        {
            var contaViewModel = await ObterConta(id);

            if (contaViewModel == null) return NotFound();

            await _contaService.Remover(id);

            if (!OperacaoValida) return View(contaViewModel);

            TempData["Sucesso"] = "Conta excluída com sucesso!";

            return RedirectToAction("Index", new { clienteId = contaViewModel.ClienteId });
        }
        
        private async Task<IEnumerable<ContaViewModel>> ObterContasPorCliente(Guid id)
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(await _contaRepository.ObterContasPorCliente(id));
        }

        private async Task<ContaViewModel> ObterConta(Guid id)
        {
            return _mapper.Map<ContaViewModel>(await _contaRepository.ObterPorId(id));
        }
    }
}