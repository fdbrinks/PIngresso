using Microsoft.AspNetCore.Mvc;
using PIngresso.Repository;

namespace PIngresso.Service
{

    public abstract class ServiceBase<T>
    {
        protected IRepository<T> repository;

        public T Create(T value)
        {
            return repository.Create(value);
        }

        public void Delete(Guid id)
        {
            repository.Delete(id);
        }

        public IList<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetById(Guid id)
        {
            var filme = repository.GetById(id);
            if (filme == null)
            {
                throw new Exception("Id Not Found");
            }
            return filme;
        }

        public T Update(T value)
        {
            return repository.Update(value);
        }
    }
}