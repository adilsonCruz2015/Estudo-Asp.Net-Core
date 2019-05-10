using ADC_Movie.Domain.Desvincular.Addres;

namespace ADC_Movie.Domain.Desvincular.Movie
{
    public class MovieDesv
    {
        private AddresDesv _addresDesv = new AddresDesv();

        public  object Completo(Entity.Movie movie)
        {
            if (Equals(movie, null))
                return null;

            return new
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate,
                Cpf = movie.Cpf,                
                Address = _addresDesv.Completo(movie.Address)
            };
        }
    }
}
