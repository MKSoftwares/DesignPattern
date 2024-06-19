using DesignPattern.Aplicacao.Servicos.Comum;
using DesignPattern.Shared.ViewModels;

namespace DesignPattern.Aplicacao.Servicos
{
    public interface IUsuarioService
    {
        ResultadoAcao<UsuarioAutenticadoVM> Autenticar(AutenticarVM usuario);

    }
}
