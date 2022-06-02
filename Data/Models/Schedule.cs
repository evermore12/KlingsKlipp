namespace KlingsKlipp.Data.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Break> Breaks { get; set; }
        public Day Day { get; set; }
    }
}
