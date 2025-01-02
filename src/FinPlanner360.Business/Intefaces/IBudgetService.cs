using FinPlanner360.Business.Models;

namespace FinPlanner360.Business.Intefaces
{
    public interface IBudgetService : IDisposable
    {
        Task Adicionar(Budget budget);
        Task Atualizar(Budget budget);
        Task Remover(Guid id);
    }
}
