using Microsoft.AspNetCore.Mvc;
namespace KlingsKlipp.Controllers;
using KlingsKlipp.Data;
using KlingsKlipp.Data.Services;

[ApiController]
[Route("[controller]")]
public class ScheduleController : Controller
{
    private readonly Database db;

    public Schedule Schedule { get; set; }
    public ScheduleController(Schedule schedule, Database db)
    {
        this.Schedule = schedule;
        this.db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Schedule.Days);
    }
    [HttpPost]
    public IActionResult Add(TimeBlock timeBlock)
    {
        Schedule.Add(timeBlock);
        return Ok();
    }
    [HttpDelete]
    public IActionResult Delete(DateTime day, int timeBlock)
    {
        return Ok();
    }
}