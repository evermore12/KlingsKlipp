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
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}
public class Booking
{
    public int Id { get; set; }
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
            Start = TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeMilliseconds(value), TimeZoneInfo.Local);
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
            End = TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeMilliseconds(value), TimeZoneInfo.Local);
        }
    }

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
public class Day
{
    public int Id { get; set; }
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
            Start = TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeMilliseconds(value), TimeZoneInfo.Local);
        }
    }
    [NotMapped]
    public long EndUnix
    {
        get
        {
            return End.ToUnixTimeMilliseconds();
        }
        set
        {
            End = TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeMilliseconds(value), TimeZoneInfo.Local);
        }
    }

}



