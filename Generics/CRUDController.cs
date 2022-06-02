using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data.Services;
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
        public T Post(T entity)
        {
            return _crudService.Create(entity);
        }

        [HttpPut]
        public void Put(T entity)
        {
            _crudService.Update(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _crudService.Delete(id);
        }
        [HttpGet("model")]
        public T Model()
        {
            return _crudService.Model;
        }
    }
}
