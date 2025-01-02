using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Models;
using FinPlanner360.Business.Models.Validations;

namespace FinPlanner360.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, INotificador notificador) : base(notificador)
        {
            _userRepository = userRepository;
        }

        public async Task Adicionar(User user)
        {
            if (!ExecutarValidacao(new UserValidation(), user)) return;

            await _userRepository.Adicionar(user);
        }

        public async Task Atualizar(User user)
        {
            if (!ExecutarValidacao(new UserValidation(), user)) return;

            await _userRepository.Atualizar(user);
        }

        public async Task Remover(Guid id)
        {
            var user = await _userRepository.ObterPorId(id);

            if (user == null)
            {
                Notificar("Registro não existe!");
                return;
            }
            await _userRepository.Remover(id);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
