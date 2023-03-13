
using PIngresso.Input;
using PIngresso.Models;
using PIngresso.Repository;

namespace PIngresso.Service
{
    public class RoomService : ServiceBase<Room>, IService<Room> 
    {
        public RoomService()
        {
            repository = new RoomRepository();
        }
    }
}
