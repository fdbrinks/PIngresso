using PIngresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace PIngresso.Repository
{
    public interface IMovieRepository
    {
        IList<Movie>  GetAll();
        Movie? GetById(Guid id);
        IQueryable<Session> FindSessions(Guid id, string date);
        Movie Create(Movie value);
        Movie Update(Movie value);
        void Delete(Guid id);
    }
}
