using Bll;
using Dto;
using Entity2;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactBll ContactBll;
        public ContactController(IContactBll ContactBll)
        {
            this.ContactBll = ContactBll;
        }
        //get-שליפה
        // GET: api/<ContactController1>
        [HttpGet]
        public List<ContactDto> Get()
        {
            return ContactBll.GetContactList();
        }

        // GET api/<ContactController1>/5
        [HttpGet("{id}")]
        public ContactDto Get(int id)
        {
            return ContactBll.GetContact(id);
        }
        //post-הוספה
        // POST api/<ContactController1>
        [HttpPost]
        public void Post([FromBody] ContactDto b)
        {
            ContactBll.AddContact(b);
        }
        //put-עדכון
        // PUT api/<ContactController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ContactDto b)
        {
            ContactBll.UpdateContact(b, id);
        }
        //delete-מחיקה
        // DELETE api/<ContactController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ContactBll.DeleteContact(id);
        }
    }
}
