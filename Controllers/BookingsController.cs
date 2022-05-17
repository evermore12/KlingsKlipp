#nullable disable
using Microsoft.AspNetCore.Mvc;

namespace KlingsKlipp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController : Controller
{
    private readonly Database _database;

    public BookingsController(Database database)
    {
        _database = database;
    }
    [HttpPost]
    public IActionResult Create(Booking booking)
    {
        _database.Bookings.Add(booking);
        _database.SaveChanges();
        return Ok(booking);
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_database.Bookings);
    }
    [HttpPut]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }
    [HttpDelete]
    public IActionResult Delete(Booking incomingBooking)
    {
        _database.Bookings.Remove(_database.Bookings.Where(booking => booking.Id == incomingBooking.Id).SingleOrDefault());
        _database.SaveChanges();
        return Ok();
    }
}
