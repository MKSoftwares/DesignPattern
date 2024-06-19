using DesignPattern.Extensoes;

namespace DesignPattern.Aplicacao.Dominios
{
    public class Grupo : Entidade
    {
        public const int DescricaoMaxLenght = 100;
        public ICollection<Produto> Produtos { get; private set; } = [];

        public string Descricao { get; private set; } = "";

        protected Grupo() { }

        public Grupo(string descricao, long usuarioAdicionou)
        {
            if (usuarioAdicionou <= 0)
                _notificacoes.AdicionarNotificacao("Usuário", "O Usuário é obrigatório");
            if (_notificacoes.Count > 0) return;

            Descricao = descricao;
            UsuarioId = usuarioAdicionou;
        }

        public void AtualizaInfo(string descricao, long usuarioAlterou)
        {
            if (usuarioAlterou <= 0)
                _notificacoes.AdicionarNotificacao("Usuário", "O Usuário é obrigatório");
            if (_notificacoes.Count > 0) return;

            Descricao = descricao;
            UsuarioId = usuarioAlterou;
        }
    }
}
