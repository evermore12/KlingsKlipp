#nullable disable
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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
    public Treatment Treatment { get; set; }
    public Customer Customer { get; set; }
    public Day Day { get; set; }

    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    [NotMapped]
    public long StartUnix
    {
        get
        {
            return Start.ToUnixTimeMilliseconds(); ;
        }
        set
        {
            Start = DateTimeOffset.FromUnixTimeMilliseconds(value);
        }
    }
    [NotMapped]
    public long EndUnix
    {
        get
        {
            return End.ToUnixTimeMilliseconds(); ;
        }
        set
        {
            End = DateTimeOffset.FromUnixTimeMilliseconds(value);
        }
    }

}
public class Treatment
{
    private TimeSpan _duration;
    private long _durationUnix;
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public TimeSpan Duration {get; set;}
    [NotMapped]
    public long DurationUnix
    {
        get
        {
            return (long)Duration.TotalMilliseconds;
        }

        set
        {
            Duration = TimeSpan.FromMilliseconds(value);
        }

    }
}
public class Day
{
    public Guid Id { get; set; }
    public List<Booking> Bookings { get; set; }
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    [NotMapped]
    public long StartUnix
    {
        get
        {
            return Start.ToUnixTimeMilliseconds(); ;
        }
        set
        {
            Start = DateTimeOffset.FromUnixTimeMilliseconds(value);
        }
    }
    [NotMapped]
    public long EndUnix
    {
        get
        {
            return End.ToUnixTimeMilliseconds(); ;
        }
        set
        {
            End = DateTimeOffset.FromUnixTimeMilliseconds(value);
        }
    }

}

//DTO's
public class CustomerDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}
public class BookingDTO
{
    public Guid Id { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public Treatment Treatment { get; set; }
    public Customer Customer { get; set; }
    public Day Day { get; set; }
}
public class TreatmentDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public long Duration { get; set; }
}
public class DayDTO
{
    public Guid Id { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public List<Booking> Bookings { get; set; }
}

