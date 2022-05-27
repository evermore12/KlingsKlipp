using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace KlingsKlipp.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : Controller
{
    private readonly Database _database;
    public ScheduleController(Database database) => _database = database;

    [HttpGet]
    public IActionResult Schedule()
    {
        return Ok(_database.Days);
    }
    [HttpGet]
    public IActionResult Schedule(DateTime start, DateTime end)
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult AddTimeBlock(DateTime start, DateTime end)
    {
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteTimeBlock(DateTime day, int timeBlock)
    {
        return Ok();
    } 
}