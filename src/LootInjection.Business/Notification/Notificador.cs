using LootInjection.Business.Interfaces.Notification;
using System.Collections.Generic;
using System.Linq;

namespace LootInjection.Business.Notification
{
    public class Notificador : INotificator
    {
        private List<Notificacao> _notificacoes;
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;

        public Notificador(List<Notificacao> notificacoes)
        {
            _notificacoes = notificacoes;
        }

        public bool PossuiNotificacoes() => _notificacoes.Any();

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }
    }
}