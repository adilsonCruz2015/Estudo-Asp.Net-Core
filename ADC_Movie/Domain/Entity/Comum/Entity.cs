using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADC_Movie.Domain.Entity.Comum
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        [NotMapped]
        public bool Valid { get; private set; }

        [NotMapped]
        public bool Invalid => !Valid;

        [NotMapped]
        public virtual ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
