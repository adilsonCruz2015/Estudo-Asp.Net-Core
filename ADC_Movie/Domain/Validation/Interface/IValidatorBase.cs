using FluentValidation.Results;

namespace ADC_Movie.Domain.Validation.Interface
{
    public interface IValidatorBase
    {
        ValidationResult ValidationResult { get; }

        bool IsValid();
    }
}
