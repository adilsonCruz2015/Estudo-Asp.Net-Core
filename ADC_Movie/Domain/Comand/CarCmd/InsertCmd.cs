using ADC_Movie.Domain.Comand.CarCmd.Validation;
using ADC_Movie.Domain.Entity;
using ADC_Movie.Domain.Interfaces;
using ADC_Movie.Domain.Validation.Interface;
using FluentValidation.Results;

namespace ADC_Movie.Domain.Comand.CarCmd
{
    public class InsertCmd : IOperation<Car>, IValidatorBase
    {
        public InsertCmd() {  }

        public string Name { get; set; }

        public ValidationResult ValidationResult { get; protected set; }

        public void Apply(ref Car value)
        {
            value = new Car(Name);
        }

        public bool IsValid()
        {
            var validator = new InsertValidatorCmd();
            this.ValidationResult = validator.Validate(this);
            return this.ValidationResult.IsValid;
        }

        public void Undo(ref Car value)
        {
            value = null;
        }
    }
}
