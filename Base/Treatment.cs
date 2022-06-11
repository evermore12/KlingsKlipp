using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
using System.ComponentModel.DataAnnotations.Schema;
namespace KlingsKlipp.Data.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public TimeOnly Duration { get; set; }
        [NotMapped]
        public long DurationUnix
        {
            get
            {
                return (long)Duration.ToTimeSpan().TotalMilliseconds;
            }
            set
            {
                Duration = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(value));
            }
        }
    }
}

namespace KlingsKlipp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreatmentController : CRUDController<Treatment>
    {
        public TreatmentController(ICRUDService<Treatment> crudService) : base(crudService)
        {
        }
    }
}
