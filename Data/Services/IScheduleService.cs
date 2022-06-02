using KlingsKlipp.Data.Models;
namespace KlingsKlipp.Data.Services
{
    public interface IScheduleService : ICRUDService<Schedule>
    {
        public IEnumerable<Schedule> Full { get; }
        public Schedule Get(DateTime day);
        public IEnumerable<Schedule> Between(DateTime firstDay, DateTime secondDay);
        public IEnumerable<Schedule> From(DateTime day);
        public IEnumerable<Schedule> To(DateTime day);

    }
}
