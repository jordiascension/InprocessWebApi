using AbastWebApi.Models;

using Microsoft.EntityFrameworkCore;

namespace InprocessWebApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }   

        public async Task<IEnumerable<Movie>> GetMovieList()
        {
            //Add this using Microsoft.EntityFrameworkCore;
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            //Movie movieInserted = await GetMovieById(movie.Id);
            return movie;
        }

        public async Task<int> DeleteMovie(int Id)
        {
            Movie movie = await GetMovieById(Id);
            _context.Movies.Remove(movie);
           int result = await _context.SaveChangesAsync();
           return result;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            Movie? movieInserted = await _context.Movies.FindAsync(id);
            return movieInserted!;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Movie movieUpdated = await GetMovieById(movie.Id);
            return movieUpdated;
        }
    }
}
