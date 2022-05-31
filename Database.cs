#nullable disable
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlingsKlipp.Data;

public class Database : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<TimeBlock> TimeBlocks { get; set; }

    public Database(DbContextOptions<Database> options) : base(options)
    {

    }
}
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public List<Booking> Bookings { get; set; }
}
public class Booking
{
    public int Id { get; set; }
    public Treatment Treatment { get; set; }
    public Customer Customer { get; set; }
    public TimeBlock TimeBlock { get; set; }
}
public class Treatment
{
    public int Id { get; set; }
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
public class TimeBlock
{
    public TimeBlock()
    {
        
    }
    public TimeBlock(TimeSpan start, TimeSpan end)
    {
        Start = start;
        End = end;
    }
    public int Id { get; set; }
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
    public DateTime Day { get; set; }
    public int? BookingId { get; set; }
    public Booking? Booking { get; set; }
    public bool IsBooked => Booking != null;
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



