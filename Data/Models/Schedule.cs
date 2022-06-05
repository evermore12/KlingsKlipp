//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//namespace KlingsKlipp.Data.Models
//{
//    public class Schedule
//    {
//        [Key]
//        public DateTime Day { get; set; }
//        public List<Booking> Bookings { get; set; }
//        public List<Break> Breaks { get; set; }
//        public TimeSpan Start { get; set; }
//        public TimeSpan End { get; set; }
//        [NotMapped]
//        public long StartUnix
//        {
//            get
//            {
//                return (long)Start.TotalMilliseconds;
//            }
//            set
//            {
//                Start = TimeSpan.FromMilliseconds(value);
//            }
//        }
//        [NotMapped]
//        public long EndUnix
//        {
//            get
//            {
//                return (long)Start.TotalMilliseconds;
//            }
//            set
//            {
//                Start = TimeSpan.FromMilliseconds(value);
//            }
//        }
//    }
//}
