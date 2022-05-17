using Microsoft.AspNetCore.Mvc;

namespace KlingsKlipp.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController
{
    private readonly Database _database;
    public ScheduleController(Database database)
    {
        _database = database;
    }
        [HttpGet]
    public IEnumerable<Day> Get()
    {
        return _database.Days;
    }
    public void AddDay(Day day)
    {
        _database.Days.Add(day);
        _database.SaveChanges();
    }

}