using System.Text.Json.Serialization;
using PIngresso.Input;

namespace PIngresso.Models
{
    public class Movie: Entity
    {
        public string? Title { get; set; }
        public string Age { get; set; }
        public int Lenght { get; set; }
        public string? Genre { get; set; }
        public string? ImageUrl { get; set; }
        [JsonIgnore]
        public List<Session>? Sessions { get; set; }

        public Movie(Guid Id, string Title, string Age, int Lenght, string Genre, string imageUrl){
        this.Id = Id;
        this.Title = Title;
        this.Age = Age;
        this.Lenght = Lenght;
        this.Genre = Genre;
        this.ImageUrl = imageUrl;
        }
        
        public static Movie parse(MovieInputModel movie) {
            return new Movie(Guid.NewGuid(), movie.Title, movie.Age, movie.Lenght, movie.Genre, movie.ImageUrl);
        }

        public static Movie parse(MovieUpdateInputModel movie) {
            return new Movie(movie.Id , movie.Title, movie.Age, movie.Lenght, movie.Genre, movie.ImageUrl); 
        }
    }
}