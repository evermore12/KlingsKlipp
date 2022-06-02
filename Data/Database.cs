#nullable disable
using Microsoft.EntityFrameworkCore;
using KlingsKlipp.Data.Models;

namespace KlingsKlipp.Data;

public class Database : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<Day> Days { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Break> Breaks { get; set; }

    public Database(DbContextOptions<Database> options) : base(options)
    {

    }
}




