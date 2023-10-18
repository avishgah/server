using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bll;
using Dto;

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {

        IOpinionBll OpinionBll;
        public OpinionController(IOpinionBll OpinionBll)
        {
            this.OpinionBll = OpinionBll;
        }
        //get-שליפה
        // GET: api/<OpinionController>
        [HttpGet]
        public List<OpinionDto> Get()
        {
            return OpinionBll.GetOptinionList();
        }

        // GET api/<OpinionController>/5
        [HttpGet("{id}")]
        public OpinionDto Get(int id)
        {
            return OpinionBll.GetOptinion(id);
        }
        //post-הוספה
        // POST api/<BikeController>
        [HttpPost]
        public void Post([FromBody] OpinionDto b)
        {
            OpinionBll.AddOptinion(b);
        }
        //put-עדכון
        // PUT api/<BikeController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OpinionDto b)
        {
            OpinionBll.UpdateOptinion(b, id);
        }
        //delete-מחיקה
        // DELETE api/<BikeController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OpinionBll.DeleteOptinion(id);
        }
    }
}
