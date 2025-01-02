using FinPlanner360.Business.Models;

namespace FinPlanner360.Business.Intefaces
{
    public interface ICategoryService : IDisposable
    {
        Task Adicionar(Category category);
        Task Atualizar(Category category);
        Task Remover(Guid id);
    }
}
