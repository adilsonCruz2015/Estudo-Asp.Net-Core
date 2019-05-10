using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ADC_Movie.Domain.Entity;

namespace ADC_MoveAPI.Models
{
    public class ADC_MoveAPIContext : DbContext
    {
        public ADC_MoveAPIContext (DbContextOptions<ADC_MoveAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ADC_Movie.Domain.Entity.Movie> Movie { get; set; }
        public DbSet<ADC_Movie.Domain.Entity.Address> Address { get; set; }
    }
}
