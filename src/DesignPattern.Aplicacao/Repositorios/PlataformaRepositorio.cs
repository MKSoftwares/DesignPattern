using DesignPattern.Aplicacao.Repositorios.Implementacao;
using DesignPattern.Aplicacao.Servicos;
using IoCdotNet;


namespace DesignPattern.Aplicacao.Repositorios
{
    public class PlataformaRepositorio : IPlataformaConexao
    {
        private readonly string servidor;
        private readonly string usuario;
        private readonly string senha;
        private readonly int porta;
        private readonly string nomeBanco;

        public PlataformaRepositorio(string servidor,
            string usuario,
            string senha,
            int porta,
            string nomeBanco)
        {
            this.servidor = servidor;
            this.usuario = usuario;
            this.senha = senha;
            this.porta = porta;
            this.nomeBanco = nomeBanco;
        }
        public void Inicializar()
        {
            BatchBinding.MagicBind(
                typeof(IPlataformaConexao).Assembly, "DesignPattern.Aplicacao.Servicos",
                typeof(PlataformaRepositorio).Assembly, "DesignPattern.Aplicacao.Repositorios");

            using (Contexto db = new ())
            {
                db.Configura(servidor, usuario, senha, porta, nomeBanco);
                db.ApplyPendingMigrations();
                //db.Empresas.Count();
            }
        }
    }
}
