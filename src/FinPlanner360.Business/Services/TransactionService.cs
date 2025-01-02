using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Models;
using FinPlanner360.Business.Models.Validations;

namespace FinPlanner360.Business.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository, INotificador notificador) : base(notificador)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Adicionar(Transaction transaction)
        {
            if (!ExecutarValidacao(new TransactionValidation(), transaction)) return;

            await _transactionRepository.Adicionar(transaction);
        }

        public async Task Atualizar(Transaction transaction)
        {
            if (!ExecutarValidacao(new TransactionValidation(), transaction)) return;
            await _transactionRepository.Atualizar(transaction);
        }

        public async Task Remover(Guid id)
        {
            var transaction  = await _transactionRepository.ObterPorId(id);

            if (transaction == null)
            {
                Notificar("Registro não existe!");
                return;
            }
            await _transactionRepository.Remover(id);
        }

        public void Dispose()
        {
            _transactionRepository.Dispose();
        }
    }
}
