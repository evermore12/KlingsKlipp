namespace KlingsKlipp.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Treatment Treatment { get; set; } = new Treatment();
        public Customer Customer { get; set; } = new Customer();
    }
}

