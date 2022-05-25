using Microsoft.AspNetCore.Mvc;

namespace KlingsKlipp.Controllers;

public class DayWithDateTime
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

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
    public Guid AddDay(Day day)
    {
        _database.Days.Add(day);
        _database.SaveChanges();
        return day.Id;
    }
    [HttpPost("/addByDateTime")]
    public Guid AddDayDateTime(DayWithDateTime dayWithDateTime)
    {
        Day day = new Day
        {
            Start = ((DateTimeOffset)dayWithDateTime.Start).ToUnixTimeMilliseconds(),
            End = ((DateTimeOffset)dayWithDateTime.End).ToUnixTimeMilliseconds()
        };
        return AddDay(day);
    }

}