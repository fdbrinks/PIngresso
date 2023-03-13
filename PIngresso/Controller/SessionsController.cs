using Microsoft.AspNetCore.Mvc;
using PIngresso.Input;
using PIngresso.Models;
using PIngresso.Service;

namespace PIngresso.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SessionsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SessionViewModel> Get()
        {
            var service = new SessionService();
            IList<Session> sessions = service.GetAll();
            return sessions.Select(r => SessionViewModel.parse(r));
        }

        [HttpGet("{id}")]
        public SessionViewModel Find(Guid id)
        {
            var SessionService = new SessionService();
            Session session = SessionService.GetById(id);
            return SessionViewModel.parse(session);
        }

        [HttpPost]
        public SessionViewModel Add(SessionInputModel input)

        {
            var SessionService = new SessionService();
            Session session = SessionService.Create(Session.parse(input));
            return SessionViewModel.parse(session);
        }
        
        [HttpPut]
        public SessionViewModel Update(SessionUpdateInputModel input)
        {
            var SessionService = new SessionService();
            Session session = SessionService.Update(Session.parse(input));
            return SessionViewModel.parse(session);
        }
        
        [HttpDelete("{id}")]
        public void Remove(Guid id)
        {
            var SessionService = new SessionService();
            SessionService.Delete(id);
        }
    }
}