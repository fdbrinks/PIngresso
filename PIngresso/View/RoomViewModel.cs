
using PIngresso.Models;

namespace PIngresso;

public class RoomViewModel
{
    public Guid Id { get; set; }
    public string Identification{ get; set; }
    public string Screen { get; set; }
    public List<Session> Sessions { get; set; }
    public RoomViewModel(Guid id, string identification, string screen, List<Session> sessions)
    {
        this.Id = id;
        this.Identification = identification;
        this.Screen = screen;
        this.Sessions = sessions;
    }

    public static RoomViewModel parse(Room room)
    {
        return new RoomViewModel(room.Id, room.Identification, room.Screen, room.Sessions);
    }

}