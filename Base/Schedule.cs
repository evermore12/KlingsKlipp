using KlingsKlipp.Data;
using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace KlingsKlipp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : Controller
    {
        IScheduleService scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }
        [HttpPost]
        public IActionResult Add(Timeblock block)
        {
            return Ok(scheduleService.Add(block));
        }
        [HttpDelete("removeBlock")]
        public IActionResult Remove(int blockId)
        {
            scheduleService.Remove(blockId);
            return Ok();
        }
        [HttpGet("between")]
        public IActionResult Between(DateTime start, DateTime end, bool onlyAvailable)
        {
            return Ok(scheduleService.Between(DateOnly.FromDateTime(start), DateOnly.FromDateTime(end), onlyAvailable));
        }
        [HttpDelete("day")]
        public IActionResult Remove(DateTime date)
        {
            scheduleService.Remove(DateOnly.FromDateTime(date));
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Day day)
        {
            Day updatedDay = scheduleService.Update(day);
            return Ok(updatedDay);
        }
    }
}
namespace KlingsKlipp.Data.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly Database database;

        public ScheduleService(Database database)
        {
            this.database = database;
        }
        public Day Add(Timeblock block)
        {
            Day day = database.Days.Find(block.DayId);
            if (day == null)
            {
                day = new Day();
                day.Date = block.DayId;
                database.Days.Add(day);
                day.Timeblocks = new List<Timeblock>();
            }

            day.Timeblocks.Add(block);

            database.SaveChanges();

            return day;
        }
        public void Remove(int blockId)
        {
            Timeblock timeblock = database.Timeblocks.Find(blockId);
            database.Timeblocks.Remove(timeblock);

            Day day = database.Days.Find(timeblock.DayId);

            if (day.Timeblocks.Count == 0)
            {
                database.Days.Remove(day);
            }

            database.SaveChanges();
        }
        public IEnumerable<Day> Between(DateOnly start, DateOnly end, bool onlyAvailable)
        {
            List<Day> schedule = new List<Day>();
            for (DateOnly i = start; i <= end; i = i.AddDays(1))
            {
                Day day = database.Days.Find(i);

                if(day != null)
                {
                    schedule.Add(day);
                }
                else if (!onlyAvailable)
                {
                    day = new() { Date = i };
                    schedule.Add(day);
                }

            }

            return schedule;
        }
        public void Remove(DateOnly date)
        {
            database.Days.Remove(database.Days.Find(date));
            database.SaveChanges();
        }
        public Day Update(Day day)
        {
            database.Days.Update(day).CurrentValues.SetValues(day);
            database.SaveChanges();
            return day;
        }
    }
}
namespace KlingsKlipp.Data.Services
{
    public interface IScheduleService
    {
        public IEnumerable<Day> Between(DateOnly start, DateOnly end, bool onlyAvailable);
        public Day Add(Timeblock block);
        public void Remove(int blockId);
        public void Remove(DateOnly date);
        public Day Update(Day day);

    }
}
