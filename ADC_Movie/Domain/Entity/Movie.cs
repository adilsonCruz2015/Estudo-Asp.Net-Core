using ADC_Movie.Domain.Validation.Movie;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADC_Movie.Domain.Entity
{
    public class Movie : Comum.Entity
    {      
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Gênero")]
        public string Genre { get; set; }

        [Display(Name = "Data Liberação")]
        public DateTime ReleaseDate { get; set; }

        public string Cpf { get; set; }

        public Address Address { get; set; }

        public string Senha { get; set; }

        [NotMapped]
        public string ConfirmaSenha { get; set; }

        public Movie()
        {
            Id = Guid.NewGuid();
        }

        public Movie(string title, 
                     string genre, 
                     DateTime releaseDate, 
                     string cpf, 
                     Address address,
                     string senha)
            :this()
        {
            Title = title;
            Genre = genre;
            ReleaseDate = releaseDate;
            Cpf = cpf;
            Address = address;
            Senha = senha;

            Validate(this, new MovieValidator());
        }
    }
}
