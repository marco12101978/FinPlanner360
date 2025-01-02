using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Models;
using FinPlanner360.Business.Models.Validations;

namespace FinPlanner360.Business.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository ;
        public CategoryService(ICategoryRepository categoryRepository,INotificador notificador) : base(notificador)
        {
            _categoryRepository = categoryRepository ;
        }

        public async Task Adicionar(Category category)
        {
            if(!ExecutarValidacao(new CategoryValidation(), category)) return;
            await _categoryRepository.Adicionar(category);
        }

        public async Task Atualizar(Category category)
        {
            if (!ExecutarValidacao(new CategoryValidation(), category)) return;
            await _categoryRepository.Atualizar(category);
        }

        public async Task Remover(Guid id)
        {
            var category = await _categoryRepository.ObterPorId(id);

            if (category == null)
            {
                Notificar("Registro não existe!");
                return;
            }
            await _categoryRepository.Remover(id);

        }

        public void Dispose()
        {
           _categoryRepository.Dispose();
        }
    }
}
