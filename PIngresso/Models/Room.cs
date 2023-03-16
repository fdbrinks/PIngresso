using System.Text.Json.Serialization;
using PIngresso.Input;

namespace PIngresso.Models
{
    public class Room : Entity
    {
        public string? Identification { get; set; }
        public string? Screen { get; set; }
        [JsonIgnore]
        public List<Session>? Sessions { get; set; }

        public Room(Guid Id, string Identification, string Screen)
        {
            this.Id = Id;
            this.Identification = Identification;
            this.Screen = Screen;
        }
    
        public static Room parse(RoomInputModel room) 
{
    return new Room(Guid.NewGuid(), room.Identification, room.Screen);
}

public static Room parse(RoomUpdateInputModel room) 
{
    return new Room(room.Id, room.Identification, room.Screen); 
}
    }
}
