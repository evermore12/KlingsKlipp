using System.ComponentModel.DataAnnotations.Schema;
namespace KlingsKlipp.Data.Models
{
    public class Day
    {
        public int Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public long StartUnix
        {
            get
            {
                return (long)Start.TotalMilliseconds;
            }
            set
            {
                Start = TimeSpan.FromMilliseconds(value);
            }
        }
        [NotMapped]
        public long EndUnix
        {
            get
            {
                return (long)Start.TotalMilliseconds;
            }
            set
            {
                Start = TimeSpan.FromMilliseconds(value);
            }
        }
    }
}
