using ADC_Movie.Domain.Comand.MovieCmd.Validation;

namespace ADC_Movie.Domain.Comand.MovieCmd.MovieCmd
{
    public class UpdateCmd : UpdatePachCmd
    {
        public UpdateCmd()
            :base() {  }

        public override bool IsValid()
        {
            var validator = new UpdateValidatorCmd();
            this.ValidationResult = validator.Validate(this);
            return this.ValidationResult.IsValid;
        }
    }
}
