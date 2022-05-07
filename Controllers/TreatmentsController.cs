using Microsoft.AspNetCore.Mvc;

namespace KlingsKlipp.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class TreatmentsController : Controller
    {
        private readonly KlingsklippContext _context;

        public TreatmentsController(KlingsklippContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            _context.SaveChanges();
            return Ok(treatment);
        }
        [HttpGet]
        public IEnumerable<Treatment> Get()
        {
            return _context.Treatments.ToArray();
        }
        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public IActionResult Delete(Treatment incomingTreatment)
        {
            _context.Treatments.Remove(_context.Treatments.Where(treatment => treatment.TreatmentId == incomingTreatment.TreatmentId).SingleOrDefault());
            _context.SaveChanges();
            return Ok();
        }

    }

