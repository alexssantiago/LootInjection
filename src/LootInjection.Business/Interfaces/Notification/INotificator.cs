using System.Collections.Generic;
using LootInjection.Business.Notification;

namespace LootInjection.Business.Interfaces.Notification
{
    public interface INotificator
    {
        bool PossuiNotificacoes();
        IReadOnlyCollection<Notificacao> Notificacoes { get; }
        void Handle(Notificacao notificacao);
    }
}