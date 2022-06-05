//using System.ComponentModel.DataAnnotations.Schema;
//namespace KlingsKlipp.Data.Models
//{
//    public class Treatment
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public int Price { get; set; }
//        public TimeSpan Duration { get; set; }
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
//    }
//}
