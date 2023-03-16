using Microsoft.AspNetCore.Mvc;
using PIngresso.Input;
using PIngresso.Models;
using PIngresso.Service;

namespace PIngresso.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<RoomViewModel> Get()
        {
            var service = new RoomService();
            IList<Room> rooms = service.GetAll();
            return rooms.Select(r => RoomViewModel.parse(r));
        }

        [HttpGet("{id}")]
        public RoomViewModel Find(Guid id)
        {
            var RoomService = new RoomService();
            Room room = RoomService.GetById(id);
            return RoomViewModel.parse(room);
        }
        
       [HttpPost]
        public RoomViewModel Add(RoomInputModel input)
        {
            var RoomService = new RoomService();
            Room room = RoomService.Create(Room.parse(input));
            return RoomViewModel.parse(room);
        }
        [HttpPut]
        public RoomViewModel Update(RoomUpdateInputModel input)
        {
            var RoomService = new RoomService();
            Room room = RoomService.Update(Room.parse(input));
            return RoomViewModel.parse(room);
        }
        
        [HttpDelete("{id}")]
        public void Remove(Guid id)
        {
            var RoomService = new RoomService();
            RoomService.Delete(id);
        }
    }
}