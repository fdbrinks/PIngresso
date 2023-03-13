using PIngresso.Input;
using System.Text.Json.Serialization;

namespace PIngresso.Models
{
    public class Session : Entity
    {
        public string? Date { get; set; }
        public string? Hour { get; set; }
        public string? Dub { get; set; }
        public string? D3 { get; set; }
        [JsonIgnore]
        public Guid MovieId { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
        [JsonIgnore]
        public Guid RoomId { get; set; }
        [JsonIgnore]
        public Room Room { get; set; }
    
        public Session(Guid Id, string Date, string Hour , string Dub, string D3, Guid MovieId, Guid RoomId)
        {
            this.Id = Id;
            this.Date = Date;
            this.Hour = Hour;
            this.Dub = Dub;
            this.D3 = D3;
            this.MovieId = MovieId;
            this.RoomId = RoomId;
        }
    
        public static Session parse(SessionInputModel session) 
        {
            return new Session(Guid.NewGuid(), session.Date, session.Hour, session.Dub, session.D3, session.MovieId, session.RoomId);
        }

        public static Session parse(SessionUpdateInputModel session) 
        {
            return new Session(session.Id , session.Date, session.Hour, session.Dub, session.D3, session.MovieId, session.RoomId); 
        }

    }
}
