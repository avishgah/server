using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bll;
using Dto;

namespace serverCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IuserBll UserBll;
        public UserController(IuserBll UserBll)
        {
            this.UserBll = UserBll;
        }
        //get-שליפה
        // GET: api/<UserController>
        [HttpGet]
        public List<CustomerDto> Get()
        {
            return UserBll.GetUserList();
        }

        // GET api/<UserController1>/5
        [HttpGet("{id}")]
        public CustomerDto Get(int id)
        {
            return UserBll.GetUser(id);
        }
        //post-הוספה
        // POST api/<UserController1>
        [HttpPost]
        public void Post([FromBody] CustomerDto b)
        {
            UserBll.AddUser(b);
        }

        [HttpPost]
        public void Post([FromBody] Connect b)
        {
            CustomerDto c=new CustomerDto() {Password=b.Password , Tz=b.Id};
            UserBll.AddUser(c);
        }



        //put-עדכון
        // PUT api/<UserController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerDto b)
        {
            UserBll.UpdateUser(b, id);
        }
        //delete-מחיקה
        // DELETE api/<UserController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserBll.DeleteUser(id);
        }
    }
}
