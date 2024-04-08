using FluentAssertions;

using InprocessWebApi.Controllers;

using Microsoft.AspNetCore.Mvc.Testing;

using Xunit.Abstractions;


namespace InprocessWebApi.Integration.Test
{
    //dotnet test --logger "console;verbosity=detailed"
    public class MovieRepositoryIntTest
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _output;

        public MovieRepositoryIntTest(ITestOutputHelper output)
         {
             var webApplicationFactory = new WebApplicationFactory<MovieController>();
             _httpClient = webApplicationFactory.CreateDefaultClient();
             this._output = output;
        }

         [Fact]
         public async Task GetMovieList_ShouldReturnListOfMovies()
         {
             var response = await _httpClient.GetAsync("/api/Movie");
             var result = await response.Content.ReadAsStringAsync();

             _output.WriteLine("This is the movie's json file {0}", result);

             result.Should().NotBeNullOrEmpty();
             result.Length.Should().BeGreaterThan(0,"No obtiene películas");
             result.Should().Contain("Dune: Parte 2","No Existe la película de Dune");
             result.Should().Contain("El clan de hierro", "No Existe la película del clan del hierro");
             
        }
    }
}