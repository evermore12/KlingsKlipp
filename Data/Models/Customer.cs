namespace KlingsKlipp.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
