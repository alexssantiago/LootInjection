using LootInjection.Business.Notification;

namespace LootInjection.Business.Interfaces.Notification
{
    public interface INotificator
    {
        bool PossuiNotificacoes();
        void Handle(Notificacao notificacao);
    }
}