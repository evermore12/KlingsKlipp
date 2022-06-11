using KlingsKlipp.Data.Models;
using KlingsKlipp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlingsKlipp.Data.Models
{
    public class Day
    {
        [Key]
        public DateOnly Date { get; set; }
        public List<Timeblock>? Timeblocks { get; set; }
    }
}
namespace KlingsKlipp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DayController : CRUDController<Day>
    {

        public DayController(ICRUDService<Day> cRUDService) : base(cRUDService)
        {
        }

    }
}

