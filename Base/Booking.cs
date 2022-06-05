using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
namespace KlingsKlipp.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Treatment Treatment { get; set; } = new Treatment();
        public Customer Customer { get; set; } = new Customer();
        [ForeignKey("TimeBlock")]
        [Required]
        public int TimeblockId { get; set; }
    }
}
namespace KlingsKlipp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : CRUDController<Booking>
    {
        public BookingController(ICRUDService<Booking> crudService) : base(crudService)
        {

        }
    }
}