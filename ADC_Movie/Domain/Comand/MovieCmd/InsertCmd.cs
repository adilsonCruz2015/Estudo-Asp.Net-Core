﻿using ADC_Movie.Domain.Comand.MovieCmd.Validation;
using ADC_Movie.Domain.Entity;
using ADC_Movie.Domain.Validation.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace ADC_Movie.Domain.Comand.MovieCmd
{
    public class InsertCmd : IValidatorBase
    {
        public InsertCmd() { }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Gênero")]
        public string Genre { get; set; }

        [Display(Name = "Data Liberação")]
        public DateTime ReleaseDate { get; set; }

        public string Cpf { get; set; }

        public string Rua { get; set; }

        public string Senha { get; set; }

        public string ConfirmaSenha { get; set; }

        public FluentValidation.Results.ValidationResult ValidationResult { get; protected set; }

        public void Aplicar(ref Movie movie)
        {
            movie = new Movie(Title, 
                              Genre, 
                              ReleaseDate, 
                              Cpf, 
                              new Address(Rua), 
                              Senha);
        }

        public bool IsValid()
        {
            var validator = new InsertValidatorCmd();
            this.ValidationResult = validator.Validate(this);
            return this.ValidationResult.IsValid;
        }
    }
}
