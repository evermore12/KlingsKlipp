using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
namespace KlingsKlipp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : CRUDController<Customer>
    {
        public CustomerController(ICRUDService<Customer> crudService) : base(crudService)
        {
        }
    }
}
