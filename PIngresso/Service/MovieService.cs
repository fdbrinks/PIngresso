
using PIngresso.Input;
using PIngresso.Models;
using PIngresso.Repository;

namespace PIngresso.Service
{
    public class MovieService : ServiceBase<Movie>, IService<Movie> 
    {
        public MovieService()
        {
            repository = new MovieRepository();
        }

        public IQueryable<Session> FindSessions(Guid id, string date)
        {
            var dates = repository.FindSessions(id, date);
            if (dates == null)
            {
                throw new Exception("Id Not Found");
            }
            return dates;
        }
    }
}
