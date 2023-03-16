using EFCoreInMemoryDbDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIngresso.Models;

namespace PIngresso.Repository
{
    public class SessionRepository : IRepository<Session>
    {
        public IList<Session> GetAll()
        {

            using (var context = new ApiContext())
            {
                return context.Sessions.Include(s => s.Movie).Include(s => s.Room).ToList();
            }
        }
        
        public Session? GetById(Guid id)
        {
            using (var context = new ApiContext())
            {
                return context.Sessions.Include(s => s.Movie).Include(s => s.Room).FirstOrDefault(s => s.Id == id);
            }
        }
        
        public Session Create(Session value)
        {
            using (var context = new ApiContext())
            {
                var movie = context.Movies.Find(value.MovieId);
                if (movie == null)
                {
                    throw new ArgumentException("MovieId inválido");
                }
                value.Movie = movie;
        
                var room = context.Rooms.Find(value.RoomId);
                if (room == null)
                {
                    throw new ArgumentException("RoomId inválido");
                }   
                value.Room = room;
        
                var existingSession = context.Sessions.FirstOrDefault(s => s.Date == value.Date
                                                                 && s.Hour == value.Hour
                                                                 && s.RoomId == value.RoomId);
                if (existingSession != null)
                {
                    throw new ArgumentException("Uma sessão com mesma data, hora e sala já existe");
                }
        
                context.Sessions.Add(value);
                context.SaveChanges();
            }
            return value;
        }
        
        public Session Update(Session value)
        {
            using (var context = new ApiContext())
            {
                var session = context.Sessions.FirstOrDefault(m => m.Id == value.Id);
                if (session != null)
                {
                    var existingSession = context.Sessions.FirstOrDefault(s => s.Date == value.Date
                                                                     && s.Hour == value.Hour
                                                                     && s.RoomId == value.RoomId
                                                                     && s.Id != value.Id);
                    if (existingSession != null)
                    {
                        throw new ArgumentException("Uma sessão com mesma data, hora e sala já existe");
                    }
            
                    session.Date = value.Date;
                    session.Hour = value.Hour;
                    session.Dub = value.Dub;
                    session.D3 = value.D3;
                    session.MovieId = value.MovieId;
                    session.RoomId = value.RoomId;
                    context.SaveChanges();
                }
            }
            return value;
        }   
        
        public void Delete(Guid id)
        {
            using (var context = new ApiContext())
            {
                var session = context.Sessions.FirstOrDefault(m => m.Id == id);
                if (session != null)
                {
                    context.Sessions.Remove(session);
                    context.SaveChanges();
                }
            }
        }

        public IQueryable<Session> FindSessions(Guid id, string date)
        {
            throw new NotImplementedException();
        }
    }

}
