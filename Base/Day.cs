using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlingsKlipp.Data.Models
{
    public class Day
    {
        [Key]
        public DateOnly Date { get; set; }
        public List<Timeblock>? Timeblocks { get; set; }
    }
}
namespace KlingsKlipp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController 
    {
        IScheduleService scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }
        //[HttpGet("full")]
        //public IEnumerable<Day> GetFull()
        //{
        //    return scheduleService.Full;
        //}
        [HttpPost]
        public Day Add(Timeblock block)
        {

            return scheduleService.Add(block);
        }
        [HttpDelete]
        public Day Remove(Timeblock block)
        {

            return scheduleService.Add(block);
        }
        //[HttpGet("from")]
        //public IEnumerable<Day> From(DateOnly day)
        //{
        //    return scheduleService.From(day);
        //}
        //[HttpDelete]
        //public IActionResult Remove(DateOnly day)
        //{
        //    scheduleService.Remove(day);
        //    return Ok();
        //}
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
            }

            database.Timeblocks.Add(block);

            database.SaveChanges();

            return new Day();
        }
        public Day Remove(int id)
        {
            Timeblock timeblock = database.Timeblocks.Find(id);
            database.Timeblocks.Remove(timeblock);

            Day day = database.Days.Find(timeblock.DayId);

            if (day.Timeblocks.Count == 0)
            {
                database.Days.Remove(day);
            }

            database.SaveChanges();

            return new Day();
        }
        //IEnumerable<Day> IScheduleService.Full => database.Days;

        //public Day Get(DateOnly day) => database.Days.Single(d => d.Date == day);
        //public IEnumerable<Day> Between(DateOnly day, DateOnly secondDay) => database.Days.Where(s => s.Date >= day && s.Date <= secondDay);
        //public IEnumerable<Day> From(DateOnly day) => database.Days.Where(s => s.Date >= day);
        //public IEnumerable<Day> To(DateOnly day) => database.Days.Where(s => s.Date <= day);
        //public void Remove(DateOnly day)
        //{
        //    Day schedule = database.Days.Find(day);
        //    database.Days.Remove(schedule);
        //}
    }
}
namespace KlingsKlipp.Data.Services
{
    public interface IScheduleService
    {
        //public IEnumerable<Day> Full { get; }
        //public Day Get(DateOnly day);
        //public IEnumerable<Day> Between(DateOnly firstDay, DateOnly secondDay);
        //public IEnumerable<Day> From(DateOnly day);
        //public IEnumerable<Day> To(DateOnly day);
        //public void Remove(DateOnly day);
        public Day Add(Timeblock block);

    }
}

