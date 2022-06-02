using KlingsKlipp.Data.Models;
using KlingsKlipp.Data;
namespace KlingsKlipp.Data.Services
{
    public class ScheduleService : CRUDService<Schedule>, IScheduleService
    {
        public ScheduleService(Database database) : base(database) 
        {
        }
        IEnumerable<Schedule> IScheduleService.Full => database.Schedules;
        public Schedule Get(DateTime day) => database.Schedules.Single(s => s.Day.Date == day);
        public IEnumerable<Schedule> Between(DateTime day, DateTime secondDay) => database.Schedules.Where(s => s.Day.Date >= day && s.Day.Date <= secondDay);
        public IEnumerable<Schedule> From(DateTime day) => database.Schedules.Where(s => s.Day.Date >= day);
        public IEnumerable<Schedule> To(DateTime day) => database.Schedules.Where(s => s.Day.Date <= day);
    }
}
