using FluentValidation;

namespace ADC_Movie.Domain.Comand.CarCmd.Validation
{
    public class InsertValidatorCmd : AbstractValidator<InsertCmd>
    {
        public InsertValidatorCmd()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} é inválido.");
        }
    }
}
