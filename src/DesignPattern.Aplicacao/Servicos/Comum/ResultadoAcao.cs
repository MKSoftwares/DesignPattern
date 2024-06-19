using DesignPattern.Extensoes;

namespace DesignPattern.Aplicacao.Servicos.Comum
{
    public class ResultadoAcao<T> : ResultadoAcao
    {
        public ResultadoAcao(T data) : base("")
        {
            Data = data;
        }
        public ResultadoAcao(string message, T data, StatusRetorno status = StatusRetorno.OK) : base(message, status)
        {
            Data = data;
        }

        public ResultadoAcao(List<Notificacao> notificacoes, StatusRetorno status = StatusRetorno.OK) : base(notificacoes, status)
        {

        }

        internal ResultadoAcao(Exception ex, StatusRetorno status = StatusRetorno.BadRequest) : base(ex, status) { }
        public T Data { get; }
    }

    public class ResultadoAcao
    {
        public string Message { get; }
        public int Status { get; }
        public IList<Notificacao> Notificacoes { get; }

        public ResultadoAcao(List<Notificacao> notificacoes, StatusRetorno status = StatusRetorno.OK)
        {
            Notificacoes = notificacoes;
            Status = (int)status;
        }

        internal ResultadoAcao(string message = null, StatusRetorno status = StatusRetorno.OK)
        {
            Status = (int)status;
            Message = message;
        }

        internal ResultadoAcao(Exception ex, StatusRetorno status = StatusRetorno.BadRequest)
        {
            Status = (int)status;
            Message = ex.Message;
            if (ex.InnerException != null)
                Message += $"\n{ex.InnerException.Message}";
        }
    }
}
