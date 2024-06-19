using DesignPattern.Extensoes;

namespace DesignPattern.Aplicacao.Dominios
{
    public class Produto : Entidade
    {
        public const int DescricaoMaxLenght = 120;

        public string Descricao { get; private set; } = "";
        public decimal Preco { get; private set; } = 0;
        public long GrupoId { get; private set; } = 0;

        public virtual Grupo Grupo { get; private set; } = null!;

        protected Produto() { }

        public Produto(string descricao, decimal preco, long grupoId, long usuarioAdicinou)
        {
            if (descricao.IsEmpty())
                _notificacoes.AdicionarNotificacao("Descrição", "A Descrição é obrigatória");
            if (descricao.Length > DescricaoMaxLenght)
                _notificacoes.AdicionarNotificacao("Descrição", $"A Descrição não pode ter mais que {DescricaoMaxLenght} caracteres.");
            if (_notificacoes.Count > 0) return;

            Descricao = descricao;
            Preco = preco;
            GrupoId = grupoId;
            UsuarioId = usuarioAdicinou;
        }

        public void AtualizaInfo(string descricao, decimal preco, long grupoId, long usuarioAlterou)
        {
            if (descricao.IsEmpty())
                _notificacoes.AdicionarNotificacao("Descrição", "A Descrição é obrigatória");
            if (descricao.Length > DescricaoMaxLenght)
                _notificacoes.AdicionarNotificacao("Descrição", $"A Descrição não pode ter mais que {DescricaoMaxLenght} caracteres.");
            if (_notificacoes.Count > 0) return;

            Descricao = descricao;
            Preco = preco;
            GrupoId = grupoId;
            UsuarioId = usuarioAlterou;
        }
    }
}
