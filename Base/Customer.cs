using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;

namespace KlingsKlipp.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Booking>? Bookings { get; set; }
    }
}
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
