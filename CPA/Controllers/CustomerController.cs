using CPA.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
         private readonly DataContext _dataContext;
        public CustomerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _dataContext.CustomersList;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer c = _dataContext.CustomersList.Find(e => e.CustomerId == id);
            if(c == null)
                return NotFound();
            return c;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer c)
        {
            _dataContext.CustomersList.Add(new Customer { CustomerId = _dataContext.CustomerCnt++, CustomerName = c.CustomerName,CustomerCaseNumber=c.CustomerCaseNumber });
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer c)
        {
            Customer c1 = new Customer();
            if (c == null)
                return NotFound();
            c1 = _dataContext.CustomersList.Find(e => e.CustomerId == id);
            if( c1 == null)
                return BadRequest();
            c1.CustomerName = c.CustomerName;
            c1.CustomerCaseNumber = c.CustomerCaseNumber;
           return NoContent();

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Customer c= _dataContext.CustomersList.Find(e => e.CustomerId == id);
            if (c == null)
                return NotFound();
            _dataContext.CustomersList.Remove(c);
            return NoContent();
        }
    }
}
