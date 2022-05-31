#nullable disable
using Microsoft.AspNetCore.Mvc;
using KlingsKlipp.Data;

namespace KlingsKlipp.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : Controller
{
    private readonly Database _database;

    public CustomersController(Database database)
    {
        _database = database;
    }
    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        _database.Customers.Add(customer);
        _database.SaveChanges();
        return Ok(customer);
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_database.Customers);
    }
    [HttpPut]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }
    [HttpDelete]
    public IActionResult Delete(Customer incomingCustomer)
    {
        _database.Customers.Remove(_database.Customers.Where(customer => customer.Id == incomingCustomer.Id).SingleOrDefault());
        _database.SaveChanges();
        return Ok();
    }
}
