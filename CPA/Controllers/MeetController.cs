using CPA.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public MeetController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/<MeetController>
        [HttpGet]
        public IEnumerable<Meet> Get()
        {
            return _dataContext.MeetsList;
        }

        // GET api/<MeetController>/5
        [HttpGet("{id}")]
        public ActionResult<Meet> Get(int id)
        {
            Meet m= _dataContext.MeetsList.Find(e=>e.MeetingId==id);
            if(m==null)
                return NotFound();
            return m;
        }
        // GET api/<MeetController>/23-08-2023
        [HttpGet("{meetingDate}")]
        public ActionResult<Meet> Get(DateTime meetingDate)
        {
            Meet m = _dataContext.MeetsList.Find(e => e.MeetingDate == meetingDate);
            if (m == null)
                return NotFound();
            return m;
        }

        // POST api/<MeetController>
        [HttpPost]
        public void Post([FromBody]  Meet m)
        {
            _dataContext.MeetsList.Add(new Meet { MeetingId = _dataContext.MeetingCnt++, MeetingHour = m.MeetingHour,MeetingDate = m.MeetingDate,MeetingDuration=m.MeetingDuration });
        }

        // PUT api/<MeetController>/5
        [HttpPut("{id}")]
        public ActionResult<Meet> Put(int id, [FromBody] Meet m )
        {
            if (m == null)
                return NotFound();
            Meet m1= _dataContext.MeetsList.Find(e=>e.MeetingId == id);
            if (m1 == null)
                return BadRequest();
            m1.MeetingHour=m.MeetingHour;
            m1.MeetingDate=m.MeetingDate;
            m1.MeetingDuration=m.MeetingDuration;
            return NoContent();
        }
        // PUT api/<MeetController>/23-08-2023
        [HttpPut("{meetingDate}")]
        public ActionResult<Meet> Put(DateTime meetingDate, [FromBody] Meet m)
        {
            if (m == null)
                return NotFound();
            Meet m1 = _dataContext.MeetsList.Find(e => e.MeetingDate == meetingDate);
            if (m1 == null)
                return BadRequest();
            m1.MeetingHour = m.MeetingHour;
            m1.MeetingDate = m.MeetingDate;
            m1.MeetingDuration = m.MeetingDuration;
            return NoContent();
        }

        // DELETE api/<MeetController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Meet m= _dataContext.MeetsList.Find(e=>e.MeetingId==id);
            if(m == null)
                return NotFound();
            _dataContext.MeetsList.Remove(m);
            return NoContent();

        }       
        // DELETE api/<MeetController>/23-08-2023
        [HttpDelete("{meetingDate}")]
        public ActionResult Delete(DateTime meetingDate)
        {
            Meet m = _dataContext.MeetsList.Find(e => e.MeetingDate == meetingDate);
            if (m == null)
                return NotFound();
            _dataContext.MeetsList.Remove(m);
            return NoContent();

        }

    }
}
