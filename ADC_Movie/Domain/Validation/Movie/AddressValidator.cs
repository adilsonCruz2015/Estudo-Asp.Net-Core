using FluentValidation;

namespace ADC_Movie.Domain.Validation.Movie
{
    public class AddressValidator : AbstractValidator<ADC_Movie.Domain.Entity.Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Rua)
                .NotEmpty()
                .WithMessage("{PropertyName} não é valida");
        }
    }
}
