using FluentValidation;

namespace FinPlanner360.Business.Models.Validations
{
    internal class GeneralBudgetValidation : AbstractValidator<GeneralBudget>
    {
        public GeneralBudgetValidation()
        {

            RuleFor(c => c.Id)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");

            RuleFor(c => c.UserId)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                   .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");

            RuleFor(x => x)
                   .Must(x => x.Amount.HasValue || x.Percentage.HasValue)
                   .WithMessage("Pelo menos um dos campos 'Amount' ou 'Percentage' deve ser preenchido.");

            RuleFor(x => x.Amount)
                    .GreaterThan(0).When(x => x.Amount.HasValue)
                    .WithMessage("O campo 'Amount' deve ser maior que zero.");

            RuleFor(x => x.Percentage)
                    .InclusiveBetween(0, 100).When(x => x.Percentage.HasValue)
                    .WithMessage("O campo 'Percentage' deve estar entre 0 e 100.");

        }
    }
}
