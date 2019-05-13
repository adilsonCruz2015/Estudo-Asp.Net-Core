
using ADC_Movie.Domain.Comand.MovieCmd.Validation;
using ADC_Movie.Domain.Entity;
using ADC_Movie.Domain.Validation.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace ADC_Movie.Domain.Comand.MovieCmd
{
    public class UpdatePachCmd : IValidatorBase
    {
        public UpdatePachCmd() { }

        [Display(Name ="Movie")]
        public Guid Id { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Gênero")]
        public string Genre { get; set; }

        [Display(Name = "Data Liberação")]
        public DateTime? ReleaseDate { get; set; }

        public string Cpf { get; set; }

        public string Rua { get; set; }

        public string Senha { get; set; }

        public string ConfirmaSenha { get; set; }

        public FluentValidation.Results.ValidationResult ValidationResult { get; protected set; }

        public void Aplicar(ref Movie movie)
        {
            if (!string.IsNullOrEmpty(Title))
                movie.Title = Title;

            if (!string.IsNullOrEmpty(Genre))
                movie.Genre = Genre;

            if (!Equals(ReleaseDate, null))
                movie.ReleaseDate = ReleaseDate.Value;

            if (!string.IsNullOrEmpty(Cpf))
                movie.Cpf = Cpf;

            if (!string.IsNullOrEmpty(Rua))
                movie.Address.Rua = Rua;

            if (!string.IsNullOrEmpty(Senha))
                movie.Senha = Senha;
        }

        public virtual bool IsValid()
        {
            var validator = new UpdatePachValidatorCmd();
            this.ValidationResult = validator.Validate(this);
            return this.ValidationResult.IsValid;
        }
    }
}
