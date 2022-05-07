using Microsoft.AspNetCore.Mvc;

namespace KlingsKlipp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController : Controller
{
    private readonly KlingsklippContext _context;

    public BookingsController(KlingsklippContext context)
    {
        _context = context;
    }
    [HttpPost]
    public IActionResult Create(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();
        return Ok(booking);
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Bookings);
    }
    [HttpPut]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }
    [HttpDelete]
    public IActionResult Delete(Booking incomingBooking)
    {
        _context.Bookings.Remove(_context.Bookings.Where(booking => booking.BookingId == incomingBooking.BookingId).SingleOrDefault());
        _context.SaveChanges();
        return Ok();
    }
}
