using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data.Services;
using KlingsKlipp.Data;
using KlingsKlipp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KlingsKlipp.Controllers
{
    public class CRUDController<T> : Controller
    {
        private readonly ICRUDService<T> _crudService;
        public CRUDController(ICRUDService<T> crudService)
        {
            this._crudService = crudService;
        }
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return _crudService.GetAll();
        }

        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _crudService.Get(id);
        }
        [HttpPost]
        public IActionResult Post(T entity)
        {
            try
            {
                _crudService.Create(entity);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }

            return Ok(entity);
        }

        [HttpPut]
        public void Put(T entity)
        {
            _crudService.Update(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _crudService.Remove(id);
        }
        [HttpGet("model")]
        public T Model()
        {
            return _crudService.Model;
        }
    }
}

namespace KlingsKlipp.Data.Services
{
    public class CRUDService<T> : ICRUDService<T> where T : class, new()
    {
        protected readonly Database database;
        public T Model => new();
        public CRUDService(Database database)
        {
            this.database = database;
        }
        public T Create(T entity)
        {
            database.Add(entity);
            try
            {
                database.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.InnerException.Message);
            }
            return entity;
        }

        public T Get(int id)
        {
            return (T)database.Find(typeof(T), id);
        }

        public void Remove(int id)
        {
            database.Remove(database.Find(typeof(T), id));
            database.SaveChanges();
        }

        public void Update(T entity)
        {
            database.Update(entity).CurrentValues.SetValues(entity);
            database.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return database.Set<T>().ToList();
        }
    }
}
namespace KlingsKlipp.Data.Services
{
    public interface ICRUDService<T>
    {
        T Model { get; }
        T Create(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Remove(int id);
    }
}
