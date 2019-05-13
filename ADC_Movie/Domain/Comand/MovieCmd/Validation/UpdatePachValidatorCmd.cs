using FluentValidation;

namespace ADC_Movie.Domain.Comand.MovieCmd.Validation
{
    public class UpdatePachValidatorCmd : AbstractValidator<UpdatePachCmd>
    {
        public UpdatePachValidatorCmd()
        {
            RuleFor(t => t.Title)
                .MaximumLength(50)
                .WithMessage("{PropertyName} deve conter no máximo 50 caracteres")
                .MinimumLength(2)
                .WithMessage("{PropertyName} deve conter no minimo 2 caracteres");

            RuleFor(g => g.Genre)
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("{PropertyName} é inválido");

            RuleFor(c => c.Cpf)
                .ValidateCpf()
                .WithMessage("{PropertyName} não pode ser em branco");

            RuleFor(r => r.Rua)
                .MaximumLength(250)
                .WithMessage("{PropertyName} deve ter no máximo 250 caracteres")
                .MinimumLength(20)
                .WithMessage("{PropertyName} deve ter no minimo 20 caracteres");

            RuleFor(s => s.Senha)
                .MaximumLength(20)
                .WithMessage("{PropertyName} deve ter no máximo 20 caracteres")
                .MinimumLength(5)
                .WithMessage("{PropertyName} deve ter no minimo 5 caracteres")
                .Equal(s => s.ConfirmaSenha)
                .WithMessage("O valor do campo: {PropertyName} deve ser igual a {PropertyValue}");
        }
    }
}
