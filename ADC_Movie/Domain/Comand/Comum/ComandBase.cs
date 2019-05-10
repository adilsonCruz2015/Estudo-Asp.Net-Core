using FluentValidation;
using FluentValidation.Results;

namespace ADC_Movie.Domain.Comand.Comum
{
    public class ComandBase
    {
        public bool Valid { get; private set; }

        public bool Invalid => !Valid;

        public virtual ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
