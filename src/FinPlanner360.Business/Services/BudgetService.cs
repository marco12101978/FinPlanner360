using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Models;
using FinPlanner360.Business.Models.Validations;

namespace FinPlanner360.Business.Services
{
    public class BudgetService : BaseService, IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        public BudgetService(IBudgetRepository budgetRepository, INotificador notificador) : base(notificador)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task Adicionar(Budget budget)
        {
            if (!ExecutarValidacao(new BudgetValidation(), budget)) return;
            await _budgetRepository.Adicionar(budget);
        }

        public async Task Atualizar(Budget budget)
        {
            if (!ExecutarValidacao(new BudgetValidation(), budget)) return;
            await _budgetRepository.Atualizar(budget);
        }

        public async Task Remover(Guid id)
        {
            var budget = await _budgetRepository.ObterPorId(id);

            if (budget == null)
            {
                Notificar("Registro não existe!");
                return;
            }
            await _budgetRepository.Remover(id);
        }

        public void Dispose()
        {
            _budgetRepository.Dispose();
        }
    }
}
