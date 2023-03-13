using Microsoft.AspNetCore.Mvc;
using PIngresso.Models;
using PIngresso.Repository;

namespace PIngresso.Service
{

    public abstract class MovieServiceBase
    {
        protected IMovieRepository repository;

        public Movie Create(Movie value)
        {
            return repository.Create(value);
        }

        public void Delete(Guid id)
        {
            repository.Delete(id);
        }

        public IList<Movie> GetAll()
        {
            return repository.GetAll();
        }

        public Movie GetById(Guid id)
        {
            var filme = repository.GetById(id);
            if (filme == null)
            {
                throw new Exception("Id Not Found");
            }
            return filme;
        }

        public Movie Update(Movie value)
        {
            return repository.Update(value);
        }
    }
}