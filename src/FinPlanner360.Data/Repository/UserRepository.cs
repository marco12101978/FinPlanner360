using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Models;
using FinPlanner360.Data.Context;

namespace FinPlanner360.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MeuDbContext context) : base(context)
        {
        }
    }
}
