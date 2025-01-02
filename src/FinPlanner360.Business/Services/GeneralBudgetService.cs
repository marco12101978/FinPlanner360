using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Models;
using FinPlanner360.Business.Models.Validations;

namespace FinPlanner360.Business.Services
{
    public class GeneralBudgetService : BaseService, IGeneralBudgetService
    {
        private readonly IGeneralBudgetRepository _generalBudgetRepository;
        public GeneralBudgetService(IGeneralBudgetRepository generalBudgetRepository, INotificador notificador) : base(notificador)
        {
            _generalBudgetRepository = generalBudgetRepository;
        }

        public async Task Adicionar(GeneralBudget generalBudget)
        {
            if (!ExecutarValidacao(new GeneralBudgetValidation(), generalBudget)) return;
            await _generalBudgetRepository.Adicionar(generalBudget);
        }

        public async Task Atualizar(GeneralBudget generalBudget)
        {
            if (!ExecutarValidacao(new GeneralBudgetValidation(), generalBudget)) return;
            await _generalBudgetRepository.Atualizar(generalBudget);
        }

        public async Task Remover(Guid id)
        {
            var generalBudget = await _generalBudgetRepository.ObterPorId(id);

            if (generalBudget == null)
            {
                Notificar("Registro não existe!");
                return;
            }
            await _generalBudgetRepository.Remover(id);
        }

        public void Dispose()
        {
            _generalBudgetRepository.Dispose();
        }
    }
}
