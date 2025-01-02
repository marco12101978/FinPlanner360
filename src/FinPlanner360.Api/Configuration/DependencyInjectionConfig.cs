using FinPlanner360.Api.Authentication;
using FinPlanner360.Business.Intefaces;
using FinPlanner360.Business.Notificacoes;
using FinPlanner360.Business.Services;
using FinPlanner360.Data.Context;
using FinPlanner360.Data.Repository;

namespace FinPlanner360.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfig(this WebApplicationBuilder builder)
        {
            builder.Services.ResolveDependencies();
            return builder;
        }

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAppIdentityUser, AppIdentityUser>();
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<MeuDbContext>();

            services.AddScoped<IBudgetRepository, BudgeRepository>();
            services.AddScoped<IBudgetService, BudgetService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IGeneralBudgetRepository,GeneralBudgetRepository >();
            services.AddScoped<IGeneralBudgetService,GeneralBudgetService >();

            services.AddScoped<ITransactionRepository,TransactionRepository>();
            services.AddScoped<ITransactionService,TransactionService>();

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository,UserRepository>();

            return services;
        }
    }
}
