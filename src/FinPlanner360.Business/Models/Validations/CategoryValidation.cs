using FinPlanner360.Business.Models.Validations.Documentos;
using FluentValidation;

namespace FinPlanner360.Business.Models.Validations
{
    internal class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");

            RuleFor(c => c.UserId)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                   .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");

            RuleFor(c => c.Description)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Length(3, 200).WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Type)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.CreatedDate)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Must(ValidacaoDatetime.EhUmaDataValida).WithMessage("O campo {PropertyName} precisa ser uma data válida");

        }
    }
}
