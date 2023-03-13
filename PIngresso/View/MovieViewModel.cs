using PIngresso.Models;

namespace PIngresso;

public class MovieViewModel
{
    public Guid Id { get; set; }
    public string Title{ get; set; }
    public string Age { get; set; }
    public int Lenght { get; set; }
    public string Genre { get; set; }
    public List<Session> Sessions { get; set; }
    public string ImageUrl { get; set; }
    
    public MovieViewModel(Guid id, string title, string age, int lenght, string genre, List<Session> sessions, string imageUrl)
    {
        this.Id = id;
        this.Title = title;
        this.Age = age;
        this.Lenght = lenght;
        this.Genre = genre;
        this.Sessions = sessions;
        this.ImageUrl = imageUrl;
    }

    public static MovieViewModel parse(Movie movie)
    {
        return new MovieViewModel(movie.Id, movie.Title, movie.Age, movie.Lenght, movie.Genre, movie.Sessions, movie.ImageUrl);
    }
}