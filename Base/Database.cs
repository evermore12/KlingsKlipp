#nullable disable
using Microsoft.EntityFrameworkCore;
using KlingsKlipp.Data.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KlingsKlipp.Data;

public class Database : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<Day> Days { get; set; }
    public DbSet<Timeblock> Timeblocks { get; set; }

    public Database(DbContextOptions<Database> options) : base(options)
    {
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
        builder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter>()
            .HaveColumnType("time");

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Day>().Navigation(e => e.Timeblocks).AutoInclude();
        builder.Entity<Timeblock>().Navigation(e => e.Bookings).AutoInclude();
        builder.Entity<Booking>().Navigation(e => e.Treatment).AutoInclude();
        builder.Entity<Booking>().Navigation(e => e.Customer).AutoInclude();
    }
    
}

/// <summary>
/// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
/// </summary>
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    /// <summary>
    /// Creates a new instance of this converter.
    /// </summary>
    public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
    { }

}
public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    /// <summary>
    /// Creates a new instance of this converter.
    /// </summary>
    public TimeOnlyConverter() : base(
            d => d.ToTimeSpan(),
            d => TimeOnly.FromTimeSpan(d))
    { }

}




