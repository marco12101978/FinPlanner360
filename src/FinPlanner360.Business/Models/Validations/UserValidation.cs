using FluentValidation;

namespace FinPlanner360.Business.Models.Validations
{
    internal class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {

            RuleFor(c => c.Id)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");

            RuleFor(c => c.AuthenticationId)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .NotEqual(Guid.Empty).WithMessage("{PropertyName} precisa ser um GUID válido");

            RuleFor(c => c.Name)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Length(3, 200).WithMessage("{PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                    .EmailAddress().WithMessage("O campo {PropertyName} deve conter um endereço de e-mail válido.");

        }
    }

}
