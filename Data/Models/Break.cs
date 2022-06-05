//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//namespace KlingsKlipp.Data.Models
//{
//    public class Break
//    {
//        public int Id { get; set; }
//        public TimeSpan Start { get; set; }
//        public TimeSpan End { get; set; }
//        [ForeignKey("Schedule")]
//        [Required]
//        public DateTime Day { get; set; }
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
