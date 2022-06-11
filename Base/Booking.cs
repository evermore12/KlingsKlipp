using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(bookingService.Get());
        }
        [HttpPost]
        public IActionResult Add(Booking booking)
        {
            return Ok( bookingService.Add(booking));
        }
    }
}

namespace KlingsKlipp.Data.Services
{
    public class BookingService : IBookingService
    {
        private readonly Database database;

        public BookingService(Database database)
        {
            this.database = database;
        }
        public Booking Add(Booking booking)
        {
            Customer customer = database.Customers.Where(x => x.Phone == booking.Customer.Phone).FirstOrDefault();
            Treatment treatment = database.Treatments.SingleOrDefault(x => x.Id == booking.Treatment.Id);
            Timeblock timeBlock = database.Timeblocks.SingleOrDefault(x => x.Id == booking.TimeblockId);
            booking.Customer = customer;
            booking.Treatment = treatment;
            timeBlock.Bookings.Add(booking);
            try
            {
                database.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
            return booking;
        }
        public IEnumerable<Booking> Get()
        {
            return database.Bookings;
        }
    }
}
namespace KlingsKlipp.Data.Services
{
    public interface IBookingService
    {
        public Booking Add(Booking booking);
        public IEnumerable<Booking> Get();

    }
}