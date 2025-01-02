using FinPlanner360.Business.Models.Validations.Documentos;
using FluentValidation;

namespace FinPlanner360.Business.Models.Validations
{
    internal class BudgetValidation : AbstractValidator<Budget>
    {
        public BudgetValidation()
        {
            RuleFor(c => c.Id)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");

            RuleFor(c => c.UserId)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");

            RuleFor(c => c.CategoryId)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");


            RuleFor(c => c.CreatedDate)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Must(ValidacaoDatetime.EhUmaDataValida).WithMessage("O campo {PropertyName} precisa ser uma data válida");

        }
    }
}
