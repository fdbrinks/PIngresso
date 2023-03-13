
using PIngresso.Models;
using PIngresso.Repository;

namespace PIngresso.Service
{
    public class SessionService : ServiceBase<Session>, IService<Session> 
    {
        public SessionService()
        {
            repository = new SessionRepository();
        }
    }
}
