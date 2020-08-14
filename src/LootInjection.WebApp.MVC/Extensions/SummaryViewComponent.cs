using System.Threading.Tasks;
using LootInjection.Business.Interfaces.Notification;
using Microsoft.AspNetCore.Mvc;

namespace LootInjection.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificator _notificator;

        public SummaryViewComponent(INotificator notificator)
        {
            _notificator = notificator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificator.Notificacoes);

            foreach (var notificacao in notificacoes)
                ViewData.ModelState.AddModelError(string.Empty, notificacao.Mensagem);

            return View();
        }
    }
}