using Microsoft.AspNetCore.Mvc;
using PIngresso.Models;

namespace PIngresso.Repository
{
    public interface IRepository<T>
    {
        IList<T>  GetAll();
        T? GetById(Guid id);
        T Create(T value);
        T Update(T value);
        void Delete(Guid id);
    }
}
