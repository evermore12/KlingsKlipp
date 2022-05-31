
namespace KlingsKlipp.Data.Services;
public class Schedule
{
    public IEnumerable<IGrouping<DateTime, TimeBlock>> Days => klingsKlippDb.TimeBlocks.ToList().GroupBy(x => x.Day);
    private readonly Database klingsKlippDb;

    public Schedule(Database KlingsKlippDb)
    {
        klingsKlippDb = KlingsKlippDb;
    }
    public void Add(TimeBlock timeBlock)
    {
        klingsKlippDb.TimeBlocks.Add(timeBlock);
        klingsKlippDb.SaveChanges();
    }
    public void Remove(TimeBlock timeBlock)
    {

    }
}