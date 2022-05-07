using Microsoft.AspNetCore.Mvc;

namespace KlingsKlipp.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : Controller
{
    private readonly KlingsklippContext _context;

    public CustomersController(KlingsklippContext context)
    {
        _context = context;
    }
    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return Ok(customer);
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Customers);
    }
    [HttpPut]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }
    [HttpDelete]
    public IActionResult Delete(Customer incomingCustomer)
    {
        _context.Customers.Remove(_context.Customers.Where(customer => customer.CustomerId == incomingCustomer.CustomerId).SingleOrDefault());
        _context.SaveChanges();
        return Ok();
    }
}
