using ADC_Movie.Domain.Comand.MovieCmd.MovieCmd;
using ADC_Movie.Domain.Validation;
using FluentValidation;

namespace ADC_Movie.Domain.Comand.MovieCmd.Validation
{
    public class UpdateValidatorCmd : CompositeValidator<UpdateCmd>
    {
        public UpdateValidatorCmd()            
        {
            RegisterBaseValidator(new UpdatePachValidatorCmd());

            RuleFor(t => t.Title)
                .NotEmpty()                
                .WithMessage("{PropertyName} é inválido");

            RuleFor(g => g.Genre)
                .NotEmpty()                
                .WithMessage("{PropertyName} é inválido");            

            RuleFor(r => r.Rua)
                .NotEmpty()
                .WithMessage("{PropertyName} é inválido");

            RuleFor(s => s.Senha)
                .NotEmpty()
                .WithMessage("{PropertyName} é inválido");

            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .WithMessage("{PropertyName} não pode ser em branco");
        }
    }
}
