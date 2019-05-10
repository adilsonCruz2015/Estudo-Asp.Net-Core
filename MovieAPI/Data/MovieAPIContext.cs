using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Models
{
    public class MovieAPIContext : DbContext
    {
        public MovieAPIContext (DbContextOptions<MovieAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MovieAPI.Models.Movie> Movie { get; set; }
    }
}
