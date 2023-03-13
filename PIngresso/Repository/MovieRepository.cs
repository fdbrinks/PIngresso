using System.Globalization;
using System.Text.RegularExpressions;
using EFCoreInMemoryDbDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIngresso.Models;

namespace PIngresso.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        public IList<Movie> GetAll()
        {
            using (var context = new ApiContext())
            {
                return context.Movies.Include(s => s.Sessions).ToList();
            }
        }
        
        public IQueryable<Session> FindSessions(Guid id, string date)
        {
            using (var context = new ApiContext())
            {
                var matchingSessions = context.Sessions.Where(s => s.MovieId == id && s.Date == date).ToList();
                return matchingSessions.AsQueryable();
            }
        }
        
        public Movie? GetById(Guid id) 
        {
            using (var context = new ApiContext())
            {
                return context.Movies.Include(s => s.Sessions).FirstOrDefault(m => m.Id == id);
            }
        }
        
    public Movie Create(Movie value)
    {
    using (var context = new ApiContext())
        {
            if (context.Movies.Any(m => RemoveSpecialCharacters(m.Title).ToLower() == RemoveSpecialCharacters(value.Title).ToLower()))
            {
                throw new ArgumentException("Um filme com esse título já existe");
            }
            value.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.Title.ToLower());
            context.Movies.Add(value);
            context.SaveChanges();
        } 
    return value;
    }
    private string RemoveSpecialCharacters(string str)
    {
        return Regex.Replace(str, "[^a-zA-Z0-9]+", "");
    }
        
        public Movie Update(Movie value)
        {
             using (var context = new ApiContext())
            {
                var existingMovie = context.Movies.FirstOrDefault(m => m.Id == value.Id);
                if (existingMovie == null)
                {
                    throw new ArgumentException("O filme não existe");
                }
                var otherMovie = context.Movies.FirstOrDefault(m => m.Title == value.Title && m.Id != value.Id);
                if (otherMovie != null)
                {
                    throw new ArgumentException("Já existe um filme com esse título");
                }
                existingMovie.Title = value.Title;
                existingMovie.Age = value.Age;
                existingMovie.Lenght = value.Lenght;
                existingMovie.Genre = value.Genre;
                existingMovie.ImageUrl = value.ImageUrl;
                context.SaveChanges();
            }
            return value;
        }
        
        public void Delete(Guid id)
        {
            using (var context = new ApiContext())
            {   
                var movie = context.Movies.FirstOrDefault(m => m.Id == id);
                if (movie != null)
                {
                    context.Movies.Remove(movie);
                    context.SaveChanges();
                }
            }
        }
    }
}
