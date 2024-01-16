using Bll;
using Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        IBikeBll bikeBll;
        public BikeController(IBikeBll bikeBll)
        {
            this.bikeBll = bikeBll;
        }
        //get-שליפה
        // GET: api/<BikeController1>
        [HttpGet]
        public List<BikeDto> Get()
        {
            return bikeBll.GetBikeList();
        }

        // GET api/<BikeController1>/5
        [HttpGet("{id}")]
        public BikeDto Get(int id)
        {
            return bikeBll.GetBike(id);
        }
        //post-הוספה
        // POST api/<BikeController1>
        [HttpPost("{count}")]
        public void Post([FromBody] BikeDto b,int count)
        {
          
            bikeBll.AddBike(b,count);
        }
        //put-עדכון
        // PUT api/<BikeController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BikeDto b)
        {
            bikeBll.UpdateBike(b,id);
        }
        //delete-מחיקה
        // DELETE api/<BikeController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bikeBll.DeleteBike(id);
        }
    }
}
