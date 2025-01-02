using FinPlanner360.Business.Models;

namespace FinPlanner360.Business.Intefaces
{
    public interface IGeneralBudgetService : IDisposable
    {
        Task Adicionar(GeneralBudget generalBudget);
        Task Atualizar(GeneralBudget generalBudget);
        Task Remover(Guid id);
    }
}
