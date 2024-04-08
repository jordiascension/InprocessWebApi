using AbastWebApi.Models;

namespace InprocessWebApi.Repositories
{

    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetMovieList();
        public Task<Movie> GetMovieById(int id);
        public Task<Movie> AddMovie(Movie movie);
        public Task<Movie> UpdateMovie(Movie movie);
        public Task<int> DeleteMovie(int Id);
    }
}
