using Microsoft.AspNetCore.Mvc;
using PIngresso.Models;

namespace PIngresso.Service
{
    public interface IService<T>
    {
        public IList<T> GetAll();
        public T GetById(Guid id);
        public T Create(T value);
        public T Update(T value);
        public void Delete(Guid id);
    }
}