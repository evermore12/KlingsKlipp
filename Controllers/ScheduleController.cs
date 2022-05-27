using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace KlingsKlipp.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : Controller
{
    private readonly Database _database;
    public ScheduleController(Database database)
    {
        _database = database;
    }
        
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_database.Days);
    }
    [HttpGet("/example")]
    public IActionResult Example()
    {
        Day day = new Day
        {
            Start = DateTimeOffset.Now,
            End = DateTimeOffset.Now
        };
        return Ok(day);
    }
    [HttpDelete]
    public void DeleteDay(int id)
    {
        Day day = _database.Days.Single(x => x.Id == id);
        _database.Entry(day).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        _database.SaveChanges();
    }

    [HttpPost]
    public IActionResult AddDay(Day day)
    {
        _database.Add(day);
        _database.SaveChanges();
        return Ok(day);
    }
}