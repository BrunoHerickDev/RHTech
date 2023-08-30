using Microsoft.EntityFrameworkCore;

namespace RhTech.Core.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ObterLista();
        Task<T> ObterPorId(int id);
        Task<T> Cadastrar(T entity);
        Task Alterar(T entity);
        Task Remover(T entity);
        DbSet<T> DbSet();
    }
}
