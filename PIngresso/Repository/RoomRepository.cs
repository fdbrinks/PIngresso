using System.Globalization;
using System.Text.RegularExpressions;
using EFCoreInMemoryDbDemo;
using Microsoft.EntityFrameworkCore;
using PIngresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace PIngresso.Repository
{
    public class RoomRepository : IRepository<Room>
    {
        public IList<Room> GetAll()
        {

            using (var context = new ApiContext())
            {
                return context.Rooms.Include(s => s.Sessions).ToList();
            }
        }
        
        public Room? GetById(Guid id)
        {
            using (var context = new ApiContext())
            {
                return context.Rooms.Include(s => s.Sessions).FirstOrDefault(m => m.Id == id);
            }
        }
       
        public Room Create(Room value)
        {
            using (var context = new ApiContext())
            {   
                if (context.Rooms.Any(m => RemoveSpecialCharacters(m.Identification).ToLower() == RemoveSpecialCharacters(value.Identification).ToLower()))
                {
                    throw new ArgumentException("Já existe uma sala com essa identificação");
                }
                value.Identification = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.Identification.ToLower());
                context.Rooms.Add(value);
                context.SaveChanges();
            }
            return value;
        }
        
        private string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9]+", "");
        }
        
        public Room Update(Room value)
        {
             using (var context = new ApiContext())
            {
                var existingRoom = context.Rooms.FirstOrDefault(m => m.Id == value.Id);
                if (existingRoom == null)
                {   
                    throw new ArgumentException("A sala não existe");
                }
        
                var otherRoom = context.Rooms.FirstOrDefault(m => m.Identification == value.Identification && m.Id != value.Id);
                if (otherRoom != null)
                {
                    throw new ArgumentException("Já existe uma sala com essa identificação");
                }
        
                existingRoom.Identification = value.Identification;
                existingRoom.Screen = value.Screen;
                context.SaveChanges();
                }
                return value;
        }
        
        public void Delete(Guid id)
        {
            using (var context = new ApiContext())
            {
                var room = context.Rooms.FirstOrDefault(m => m.Id == id);
                if (room != null)
                {
                    context.Rooms.Remove(room);
                    context.SaveChanges();
                }
            }
        }
    }

}
