//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bll;
using Dto;

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {

        IStattionBll StationBll;
        public StationController(IStattionBll StationBll)
        {
            this.StationBll = StationBll;
        }
        //get-שליפה
        // GET: api/<StationController1>
        [HttpGet]
        public List<StationDto> Get()
        {
            return StationBll.GetStationList();
        }

        // GET api/<StationController1>/5
        [HttpGet("{id}")]
        public StationDto Get(int id)
        {
            return StationBll.GetStation(id);
        }
        //post-הוספה
        // POST api/<StationController1>
        [HttpPost]
        public void Post([FromBody] StationDto b)
        {
           
            StationBll.AddStation(b);
        }
        //put-עדכון
        // PUT api/<BikeController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StationDto b)
        {
            StationBll.UpdateStation(b, id);
        }
        //delete-מחיקה
        // DELETE api/<BikeController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StationBll.DeleteStation(id);
        }
    }
}
