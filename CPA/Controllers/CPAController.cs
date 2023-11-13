using CPA.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPAController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public CPAController(DataContext dataContext)
        {
            _dataContext=dataContext;

        }

        // GET: api/<CPAController>
        [HttpGet]
        public IEnumerable<cpa> Get()
        {
            return _dataContext.CPAList;
        }

        // GET api/<CPAController>/5
        [HttpGet("{id}")]
        public ActionResult<cpa> Get(int id)
        {
            cpa c= _dataContext.CPAList.Find(e=>e.CPAId==id);
            if(c==null)
                return NotFound();
            return c;
        }

        // POST api/<CPAController>
        [HttpPost]
        public void Post([FromBody]  cpa c)
        {
            _dataContext.CPAList.Add(new cpa { CPAId= _dataContext.CPACnt++,CPAName=c.CPAName,SeniorityYears=c.SeniorityYears});
        }

        // PUT api/<CPAController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] cpa c)
        {
            if (c == null)
                return NotFound();
            cpa c1= _dataContext.CPAList.Find(e=>e.CPAId==id);
            if (c1 == null)
                return BadRequest();
            c1.CPAName=c.CPAName;
            c1.SeniorityYears = c.SeniorityYears;
            return NoContent();
        }

        // DELETE api/<CPAController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cpa c= _dataContext.CPAList.Find(e=>e.CPAId==id);
            _dataContext.CPAList.Remove(c);
        }
    }
}
