using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ADC_MoveAPI.Models;
using ADC_Movie.Domain.Entity;
using ADC_Back.Validation;
using ADC_Movie.Domain.Comand.MovieCmd;
using ADC_Movie.Domain.Desvincular.Movie;

namespace ADC_MoveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ADC_MoveAPIContext _context;
        private readonly NotificationContext _notificationContext;
        private MovieDesv _movieDesv;

        public MoviesController(ADC_MoveAPIContext context,
                                NotificationContext notificationContext)
        {
            _context = context;
            this._notificationContext = notificationContext;
            _movieDesv = new MovieDesv();
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetMovie()
        {
            return await _context.Movie.Select(x => _movieDesv.Completo(x)).ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetMovie(Guid id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _movieDesv.Completo(movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(Guid id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(InsertCmd comando)
        {
            this._notificationContext.Clear();
            if(comando.EhValido())
            {
                this._notificationContext.AddNotifications(comando.ValidationResult);
                return CreatedAtAction("GetMovie", comando);
            }
            Movie movie = null;
            comando.Aplicar(ref movie);
            _context.Address.Add(movie.Address);
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovie", new { id = movie.Id },_movieDesv.Completo(movie));
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(Guid id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(Guid id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
