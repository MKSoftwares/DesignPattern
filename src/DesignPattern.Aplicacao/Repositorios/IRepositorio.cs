namespace DesignPattern.Aplicacao.Repositorios
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        void Adicionar(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Remover(TEntity entidade);
        TEntity? ObterPorId(object id);
    }
}
