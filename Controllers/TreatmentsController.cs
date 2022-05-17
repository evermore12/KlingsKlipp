#nullable disable
using Microsoft.AspNetCore.Mvc;

namespace KlingsKlipp.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class TreatmentsController : Controller
    {
        private readonly Database _database;

        public TreatmentsController(Database database)
        {
            _database = database;
        }
        [HttpPost]
        public IActionResult Create(Treatment treatment)
        {
            _database.Treatments.Add(treatment);
            _database.SaveChanges();
            return Ok(treatment);
        }
        [HttpGet]
        public IEnumerable<Treatment> Get()
        {
            return _database.Treatments.ToArray();
        }
        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public IActionResult Delete(Treatment incomingTreatment)
        {
            _database.Treatments.Remove(_database.Treatments.Where(treatment => treatment.Id == incomingTreatment.Id).SingleOrDefault());
            _database.SaveChanges();
            return Ok();
        }

    }

