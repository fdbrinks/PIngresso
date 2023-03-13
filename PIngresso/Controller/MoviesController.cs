using Microsoft.AspNetCore.Mvc;
using PIngresso.Input;
using PIngresso.Models;
using PIngresso.Service;

namespace PIngresso.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MovieViewModel> Get()
        {
            var service = new MovieService();
            IList<Movie> movies = service.GetAll();
            return movies.Select(r => MovieViewModel.parse(r));
        }
        
        [HttpGet("{id}/find-sessions")]
        public IQueryable<Session> FindSessions([FromRoute]Guid id, string date)
        {   
            var MovieService = new MovieService();
            IQueryable<Session> sessions = MovieService.FindSessions(id, date);
            return sessions;
        }
        
        [HttpGet("{id}")]
        public MovieViewModel Find(Guid id)
        {   
            var MovieService = new MovieService();
            Movie movie = MovieService.GetById(id);
            return MovieViewModel.parse(movie);
        }
        
        [HttpPost]
        public MovieViewModel Add(MovieInputModel input)
        {
            var MovieService = new MovieService();
            Movie movie = MovieService.Create(Movie.parse(input));
            return MovieViewModel.parse(movie);
        }
        
        [HttpPut]
        public MovieViewModel Update(MovieUpdateInputModel input)
        {   
            Console.WriteLine(input.Title);
            var MovieService = new MovieService();
            Movie movie = MovieService.Update(Movie.parse(input));
            return MovieViewModel.parse(movie);
        }
        
        [HttpDelete("{id}")]
        public void Remove(Guid id)
        {
            var MovieService = new MovieService();
            MovieService.Delete(id);
        }
    }
}