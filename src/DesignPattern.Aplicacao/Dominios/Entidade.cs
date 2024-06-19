using DesignPattern.Extensoes;

namespace DesignPattern.Aplicacao.Dominios
{
    public abstract class Entidade : INotificacao
    {
        protected List<Notificacao> _notificacoes = [];
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;

        public long Id { get; private set; }
        public long UsuarioId { get; protected set; }

        public virtual Usuario Usuario { get; protected set; } = null!;
    }
}
