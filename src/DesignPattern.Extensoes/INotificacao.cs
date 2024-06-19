namespace DesignPattern.Extensoes
{
    public interface INotificacao
    {
        IReadOnlyCollection<Notificacao> Notificacoes { get; }
    }
}
