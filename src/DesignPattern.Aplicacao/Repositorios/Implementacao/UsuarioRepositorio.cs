using DesignPattern.Aplicacao.Dominios;
using System.Linq.Expressions;

namespace DesignPattern.Aplicacao.Repositorios.Implementacao
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto db;
        public UsuarioRepositorio()
        {
            db = new Contexto();
        }

        public long AdicionarUsuario(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.Save();
            return usuario.Id;
        }

        public void Adicionar(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.Save();
        }

        public void Atualizar(Usuario usuario)
        {
            db.Usuarios.Update(usuario);
            db.Save();
        }

        public Usuario? Autenticar(string login, string senha)
        {
            //senha = senha.Encrypt();
            return db.Usuarios.FirstOrDefault(e => (e.Login.Equals(login) || e.Login.Equals(login)) && e.Senha.Equals(senha));
        }

        public IQueryable<Usuario> Consulta(Expression<Func<Usuario, bool>> consulta)
        {
            throw new NotImplementedException();
        }

        public Usuario? ObterPorId(object id)
        {
            return db.Usuarios.Find(id);
        }

        public void Remover(Usuario usuario)
        {
            db.Usuarios.Remove(usuario);
            db.Save();
        }

        public Usuario? ObterPorLogin(string login)
        {
            return db.Usuarios.FirstOrDefault(e => e.Login.Equals(login));
        }
    }
}
