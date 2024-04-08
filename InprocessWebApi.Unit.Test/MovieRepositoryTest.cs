using AbastWebApi.Models;
using InprocessWebApi.Repositories;

using Moq;

namespace InprocessWebApi.Unit.Test
{
    public class MovieRepositoryTest
    {
        private readonly Mock<IMovieRepository> _mockMovieRepository;

        public MovieRepositoryTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
        }

        [Fact]
        public async Task GetMovieList_ShouldReturnListOfMovies()
        {
            // Arrange
            var expectedMovies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Movie 1", Genre="Drama", ReleaseDate=new DateTime(2015, 12, 25)},
                new Movie { Id = 2, Title = "Movie 2", Genre="Terror" , ReleaseDate=new DateTime(2014, 11, 26)},
                new Movie { Id = 3, Title = "Movie 3", Genre="Action", ReleaseDate=new DateTime(2012, 10, 24) }
            };

            _mockMovieRepository.Setup(repo => repo.GetMovieList())
                .ReturnsAsync(expectedMovies);

            var movieRepository = _mockMovieRepository.Object;

            // Act
            var result = await movieRepository.GetMovieList();

            // Assert
            Assert.Equal(expectedMovies, result);
        }
    }
}