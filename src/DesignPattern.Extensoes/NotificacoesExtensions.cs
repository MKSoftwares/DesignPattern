namespace DesignPattern.Extensoes
{
    public static class NotificacoesExtensions
    {
        public static void AdicionarNotificacao(this List<Notificacao> notificacoes, string chave, string mensagem)
        {
            notificacoes.Add(new Notificacao { Key = chave, Message = mensagem });
        }

        public static void AdicionarNotificacoes(this List<Notificacao> notificacoes, IReadOnlyCollection<Notificacao> notif)
        {
            foreach (var notificacao in notif)
                notificacoes.Add(notificacao);
        }
    }
}
