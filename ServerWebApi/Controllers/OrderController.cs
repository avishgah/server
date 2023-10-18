using Microsoft.AspNetCore.Mvc;
using Bll;
using Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBll orderBll;
        public OrderController(IOrderBll orderBll)
        {
            this.orderBll = orderBll;
        }

        // GET: api/<OrderController>
        [HttpGet]
     
        public List<OrderDto> Get()
        {
            return orderBll.GetOrderList();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDto Get(int id)
        {
            return orderBll.GetOrder(id);
        }
        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderDto b)
        {
            orderBll.AddOrder(b);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDto b)
        {
            orderBll.UpdateOrder(b, id);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderBll.DeleteOrder(id);
        }
    }
}
