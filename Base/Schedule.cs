using KlingsKlipp.Data;
using KlingsKlipp.Data.Models;

namespace KlingsKlipp.Base
{
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

            public Day Remove(Timeblock block)
            {
                database.Timeblocks.Remove(block);

                Day day = database.Days.Find(block.DayId);

                if (day.Timeblocks.Count == 0)
                {
                    database.Days.Remove(day);
                }

                database.SaveChanges();

                return new Day();
            }
            public Day Get(DateOnly day) => database.Days.Single(d => d.Date == day);
            public IEnumerable<Day> Between(DateOnly day, DateOnly secondDay) => database.Days.Where(s => s.Date >= day && s.Date <= secondDay);
            public IEnumerable<Day> From(DateOnly day) => database.Days.Where(s => s.Date >= day);
            public IEnumerable<Day> To(DateOnly day) => database.Days.Where(s => s.Date <= day);
        }
    }
    namespace KlingsKlipp.Data.Services
    {
        public interface IScheduleService
        {
            public IEnumerable<Day> Between(DateOnly firstDay, DateOnly secondDay);
            public IEnumerable<Day> From(DateOnly day);
            public IEnumerable<Day> To(DateOnly day);
            public Day Add(Timeblock block);
            public Day Remove(Timeblock block);

        }
    }
}
