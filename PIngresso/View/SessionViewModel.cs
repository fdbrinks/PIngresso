using PIngresso.Models;

namespace PIngresso;

public class SessionViewModel
{
    public Guid Id { get; set; }
    public string Date{ get; set; }
    public string Hour { get; set; }
    public string? Dub { get; set; }
    public string? D3 { get; set; }
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
    public SessionViewModel(Guid id, string date, string hour, string dub, string d3, Guid movieId, Movie movie, Guid roomId, Room room)
    {
        this.Id = id;
        this.Date = date;
        this.Hour = hour;
        this.Dub = dub;
        this.D3 = d3;
        this.MovieId = movieId;
        this.Movie = movie;
        this.RoomId = roomId;
        this.Room = room;
    }

    public static SessionViewModel parse(Session session)
    {
        return new SessionViewModel(session.Id, session.Date, session.Hour, session.Dub, session.D3, session.MovieId, session.Movie, session.RoomId, session.Room);
    }
}