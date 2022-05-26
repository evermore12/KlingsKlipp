#nullable disable
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace KlingsKlipp.Controllers;


[ApiController]
[Route("[controller]")]
public class BookingsController : Controller
{
    private readonly Database _database;
    private readonly IMapper _mapper;

    public BookingsController(Database database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    // [HttpGet]
    // public IActionResult Get()
    // {
    //     List<BookingDTO> bookingDTOs = _mapper.Map<List<BookingDTO>>(_database.Bookings);
    //     return Ok(new Booking());
    // }

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


    // public IActionResult Create(BookingDTO bookingDTO)
    // {
    //     Booking booking = _mapper.Map<Booking>(bookingDTO);
    //     _database.Add(booking);
    //     _database.SaveChanges();
    //     return Ok(booking.Id);
    // }
    // [HttpPost("[controller]/CreateWithDateTime")]
    // public IActionResult CreateWithDateTime(Booking booking)
    // {
    //     _database.Add(booking);
    //     _database.SaveChanges();
    //     return Ok(booking.Id);
    // }