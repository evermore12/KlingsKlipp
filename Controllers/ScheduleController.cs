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
    [HttpDelete]
    public void DeleteDay()
    {
        foreach (Day Day in _database.Days)
        {
            _database.Entry(Day).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }
        _database.SaveChanges();
    }
    [HttpPost]
    public IActionResult AddDay(Day day)
    {
        _database.Add(day);
        _database.SaveChanges();
        return Ok(day.Id);
    }
}