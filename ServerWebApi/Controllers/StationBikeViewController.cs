using Bll;
using Entity2;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationBikeViewController : ControllerBase
    {
        IStationBikeView StationBikeViewBll;
        public StationBikeViewController(IStationBikeView StationBikeViewBll)
        {
            this.StationBikeViewBll = StationBikeViewBll;
        }
        //get-שליפה
        // GET: api/<StationBikeViewController1>
        [HttpGet]
        public List<StationBikeViewDto> Get()
        {
          return StationBikeViewBll.GetStationBikeViewList();
        }

        // GET api/<StationBikeViewController1>/5
        [HttpGet("{id}")]
        public StationBikeViewDto Get(int id)
        {
            return StationBikeViewBll.GetStationBikeView(id);
        }
        //post-הוספה
        // POST api/<StationBikeViewController1>
        [HttpPost]
        public void Post([FromBody] StationBikeViewDto b)
        {
          
            StationBikeViewBll.AddStationBikeView(b);
        }
        //put-עדכון
        // PUT api/<StationBikeViewController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StationBikeViewDto b)
        {
            StationBikeViewBll.UpdateStationBikeView(b,id);
        }
        //delete-מחיקה
        // DELETE api/<StationBikeViewController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StationBikeViewBll.DeleteStationBikeView(id);
        }
    
    }
}
