﻿using AutoMapper;
using FinPlanner360.Api.ViewModels.Budget;
using FinPlanner360.Api.ViewModels.Category;
using FinPlanner360.Api.ViewModels.GeneralBudget;
using FinPlanner360.Api.ViewModels.Transaction;
using FinPlanner360.Api.ViewModels.User;
using FinPlanner360.Business.Models;

namespace FinPlanner360.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static WebApplicationBuilder AddAutoMapperConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return builder;
        }
    }

    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Budget, BudgetViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<GeneralBudget, GeneralBudgetViewModel>().ReverseMap();
            CreateMap<Transaction, TransactionViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
