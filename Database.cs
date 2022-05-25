#nullable disable
using Microsoft.EntityFrameworkCore;

namespace KlingsKlipp;

public class Database : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Day> Days { get; set; }

    public Database(DbContextOptions<Database> options) : base(options)
    {

    }
}
public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}
public class Booking
{
    public Guid Id { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public Treatment Treatment { get; set; }
    public Customer Customer { get; set; }
    public Day Day { get; set; }
}
public class Treatment
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public long Duration { get; set; }
}
public class Day
{
    public Guid Id { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public List<Booking> Bookings { get; set; }
}
