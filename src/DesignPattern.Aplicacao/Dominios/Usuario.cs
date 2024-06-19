using DesignPattern.Extensoes;

namespace DesignPattern.Aplicacao.Dominios
{
    public class Usuario : INotificacao
    {
        protected List<Notificacao> _notificacoes = [];
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;

        public const int SenhaMaxLenght = 255;
        public const int LoginMaxLenght = 100;
        public const int NomeMaxLenght = 100;

        public long Id { get; private set; }
        public string Login { get; private set; } = "";
        public string Nome { get; private set; } = "";
        public string Senha { get; private set; } = "";

        public virtual ICollection<Grupo> Grupos { get; private set; } = [];
        public virtual ICollection<Produto> Produtos { get; private set; } = [];

        protected Usuario() { }

        public Usuario(string login, string nome, string senha)
        {
            if (nome.IsEmpty() || nome.Length > NomeMaxLenght)
                _notificacoes.AdicionarNotificacao("Nome", $"O Nome é obrigatório, e deve ter no máximo {NomeMaxLenght} caracteres");
            if (login.IsEmpty() || login.Length > LoginMaxLenght)
                _notificacoes.AdicionarNotificacao("Login", $"O Login é obrigatório, e deve ter no máximo {LoginMaxLenght} caracteres");
            if (senha.IsEmpty() || senha.Length > SenhaMaxLenght)
                _notificacoes.AdicionarNotificacao("Senha", $"A Senha é obrigatória, e deve ter no máximo {SenhaMaxLenght} caracteres");

            if (_notificacoes.Count > 0)
                return;

            Login = login;
            Senha = senha;
            Nome = nome;
        }

        public void AtualizarSenha(string senha)
        {
            if (senha.IsEmpty() || senha.Length > SenhaMaxLenght)
                _notificacoes.AdicionarNotificacao("Senha", $"A Senha é obrigatória, e deve ter no máximo {SenhaMaxLenght} caracteres");

            if (_notificacoes.Count > 0)
                return;

            Senha = senha;
        }
    }
}
