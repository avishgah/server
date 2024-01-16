using Bll;
using Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrdersViewController : ControllerBase
    {
        ICustomerOrdersBll bikeBll;
        public CustomerOrdersViewController(ICustomerOrdersBll bikeBll)
        {
            this.bikeBll = bikeBll;
        }
        //get-שליפה
        // GET: api/<BikeController1>
        [HttpGet]
        public List<CustomerOrdersViewDto> Get()
        {
            return bikeBll.GetCustomerOrdersList();
        }

        // GET api/<BikeController1>/5
        [HttpGet("{id}")]
        public CustomerOrdersViewDto Get(int id)
        {
            return bikeBll.GetCustomerOrders(id);
        }
        //post-הוספה
        // POST api/<BikeController1>
        [HttpPost]
        public void Post([FromBody] CustomerOrdersViewDto b)
        {

            bikeBll.AddCustomerOrders(b);
        }
        //put-עדכון
        // PUT api/<BikeController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerOrdersViewDto b)
        {
            bikeBll.UpdateCustomerOrders(b, id);
        }
        //delete-מחיקה
        // DELETE api/<BikeController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bikeBll.DeleteCustomerOrders(id);
        }
    }
}
