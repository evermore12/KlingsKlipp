using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KlingsKlipp.Data.Models
{
    public class Timeblock
    {
        public int Id { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        [Required]
        [ForeignKey("Day")]
        public DateOnly DayId { get; set; }
        public Day? Day { get; set; }
        public List<Booking>? Bookings { get; set; }
        [NotMapped]
        public long StartUnix
        {
            get
            {
                return (long)Start.ToTimeSpan().TotalMilliseconds;
            }
            set
            {
                Start = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(value));
            }
        }
        [NotMapped]
        public long EndUnix
        {
            get
            {
                return (long)End.ToTimeSpan().TotalMilliseconds;
            }
            set
            {
                End = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(value));
            }
        }
    
        //        [NotMapped]
//        public long DurationUnix
//        {
//            get
//            {
//                return (long)Duration.TotalMilliseconds;
//            }

//            set
//            {
//                Duration = TimeSpan.FromMilliseconds(value);
//            }

//        }

    }
}

namespace KlingsKlipp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeblockController : CRUDController<Timeblock>
    {

        public TimeblockController(ICRUDService<Timeblock> cRUDService) : base(cRUDService)
        {
        }

    }
}



