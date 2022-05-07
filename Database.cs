using Microsoft.EntityFrameworkCore;

namespace KlingsKlipp;

public class KlingsklippContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public KlingsklippContext(DbContextOptions<KlingsklippContext> options) : base(options)
    {

    }
}
public class Customer
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}
public class Booking
{
    public Guid BookingId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Treatment Treatment { get; set; }
}
public class Treatment
{
    public Guid TreatmentId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public TimeSpan Duration { get; set; }
}
