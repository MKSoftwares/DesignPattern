using DesignPattern.Aplicacao.Repositorios;
using DesignPattern.Aplicacao.Servicos.Comum;
using DesignPattern.Shared.ViewModels;
using IoCdotNet;


namespace DesignPattern.Aplicacao.Servicos.Implementacao
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioService()
        {
            EmpUsuRepos = IoC.Resolve<IUsuarioRepositorio>();
        }

        private IUsuarioRepositorio EmpUsuRepos;

        public ResultadoAcao<UsuarioAutenticadoVM> Autenticar(AutenticarVM usuario)
        {
            throw new NotImplementedException();
        }
    }
}
