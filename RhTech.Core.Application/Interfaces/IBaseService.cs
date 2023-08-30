namespace RhTech.Core.Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T> ObterPorId(int id);

        Task<List<T>> ObterLista();

        Task<T> Cadastrar(T viewModel);

        Task Alterar(T viewModel);

        Task Remover(int id);
    }
}
