using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
namespace KlingsKlipp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : CRUDController<Schedule>
    {
        IScheduleService scheduleService;
        public ScheduleController(IScheduleService scheduleService) : base(scheduleService)
        {
            this.scheduleService = scheduleService;
        }
        [HttpGet("full")]
        public IEnumerable<Schedule> GetFull()
        {
            return scheduleService.Full;
        }
        [HttpGet("from")]
        public IEnumerable<Schedule> From(DateTime day)
        {
            return scheduleService.From(day);
        }
    }
}