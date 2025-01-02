using FinPlanner360.Business.Models;

namespace FinPlanner360.Business.Intefaces
{
    public interface ITransactionService : IDisposable
    {
        Task Adicionar(Transaction transaction);
        Task Atualizar(Transaction transaction);
        Task Remover(Guid id);
    }
}
