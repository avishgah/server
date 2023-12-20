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
        [HttpGet("/api/order/get/{id}")]
        public OrderDto Get(int id)
        {
            return orderBll.GetOrder(id);
        }


        [HttpGet("/api/order/isExist/{id}/{count}")]
        public ActionResult<bool> IsExist(int id, int count)
        {
            return orderBll.IsExist(id, count);
        }



        //????????
        [HttpGet("/api/order/GetOrderByIdCust/{id}")]
        public List<OrderDto> GetOrderByIdCust(string id)
        {
            return orderBll.GetOrderByIdCust(id);
        }
        //????????
        [HttpGet("/api/order/GetOrderByIdCustNotDone/{id}")]
        public List<OrderDto> GetOrderByIdCustNotDone(string id)
        {
            return orderBll.GetOrderByIdCustNotDone(id);
        }

        [HttpGet("/api/order/updateSum/{id}")]
        public double putEndSum(string id)
        {
            return orderBll.UpdateEndSumOfOrder(id);
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
