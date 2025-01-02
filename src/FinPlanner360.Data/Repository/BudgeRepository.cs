using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Models;
using FinPlanner360.Data.Context;

namespace FinPlanner360.Data.Repository
{
    public class BudgeRepository : Repository<Budget>, IBudgetRepository
    {
        public BudgeRepository(MeuDbContext context) : base(context)
        {
        }
    }
}
