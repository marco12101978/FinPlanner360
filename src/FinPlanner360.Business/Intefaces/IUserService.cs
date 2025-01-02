using FinPlanner360.Business.Models;

namespace FinPlanner360.Business.Intefaces
{
    public interface IUserService : IDisposable
    {
        Task Adicionar(User user);
        Task Atualizar(User user);
        Task Remover(Guid id);
    }
}
