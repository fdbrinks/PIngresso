using PIngresso.Models;

namespace PIngresso;

public class MovieSessionsViewModel
{
    public Guid Id { get; set; }
    public MovieSessionsViewModel(Guid id)
    {
        this.Id = id;
    }

    public static MovieSessionsViewModel parse(Movie movie)
    {
        return new MovieSessionsViewModel(movie.Id);
    }
}