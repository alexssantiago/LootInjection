using LootInjection.Business.Interfaces.Notification;
using Microsoft.AspNetCore.Mvc;

namespace LootInjection.WebApp.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificator _notificator;

        protected BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool OperacaoValida => !_notificator.PossuiNotificacoes();
    }
}