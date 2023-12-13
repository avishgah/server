using Bll;
using Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationViewControllers : ControllerBase
    {
        IStationViewBll stationBll;
        public StationViewControllers(IStationViewBll bikeBll)
        {
            this.stationBll = bikeBll;
        }
        // GET: api/<StationVController>
        [HttpGet]
        public List<StationViewDto> Get()
        {
            return stationBll.GetStationList();
        }

        // GET api/<StationVController>/5
        [HttpGet("{id}")]
        public StationViewDto Get(int id)
        {
            return stationBll.GetStation(id);
        }

        // POST api/<StationVController>
        [HttpPost]
        public void Post([FromBody] StationViewDto b)
        {

            stationBll.AddStation(b);
        }

        // PUT api/<StationVController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StationViewDto b)
        {
            stationBll.UpdateStation(b, id);
        }

        // DELETE api/<StationVController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stationBll.DeleteStation(id);

        }
    }
}
