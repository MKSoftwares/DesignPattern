using DesignPattern.Aplicacao.Dominios;

namespace DesignPattern.Aplicacao.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        long AdicionarUsuario(Usuario usuario);
        Usuario? Autenticar(string login, string senha);
        Usuario? ObterPorLogin(string login);

    }
}
