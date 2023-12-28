using Microsoft.AspNetCore.Mvc;
using Bll;
using Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderBikeController : ControllerBase
    {
        IOrderBikeBll OrderBike;
        public OrderBikeController(IOrderBikeBll OrderBikeBll)
        {
            this.OrderBike = OrderBikeBll;
        }
        //get-שליפה
        // GET: api/<BikeController1>
        [HttpGet]
        public List<OrderBikeDto> Get()
        {
            return OrderBike.GetOrderBikeList();
        }

        // GET api/<BikeController1>/5
        [HttpGet("/api/orderBike/GetOrderById/{id}")]
        public OrderBikeDto Get(int id)
        {
            return OrderBike.GetOrderBike(id);
        }
        // GET api/<BikeController1>/5
        [HttpGet("/api/orderBike/HistoryDrive/{id}")]
        public List<OrderBikeDto> Get(string id)
        {
            return OrderBike.HistoryDrive(id);
        }

        [HttpGet("/api/orderBike/GetOrderByIdOrder/{id}")]
        public List<OrderBikeDto> GetOrders(int id)
        {
            return OrderBike.GetOrderBikeListByIdList(id);
        }


        [HttpGet("/api/orderBike/GetListDateOfUse/{id}")]
        public List<TimeSpan> GetListDateOfUse(string id)
        {
            return OrderBike.GetListDateOfUse(id);
        }

        [HttpGet("/api/orderBike/ReturnListBikeByIdOrder/{id}")]
        public List<OrderBikeDto> ReturnListBikeByIdOrder(int id)
        {
            return OrderBike.ReturnListBikeByIdOrder(id);
        }


        [HttpGet("/api/orderBike/calcTime/{id}")]
        public TimeSpan CalcTime(int id)
        {
            return OrderBike.CalcTime(id);
        }
        [HttpGet("/api/orderBike/calcSum/{id}")]
        public double CalcSum(int id)
        {
            return OrderBike.CalcSum(id);
        }
        //post-הוספה
        // POST api/<BikeController1>
        [HttpPost]
        public void Post([FromBody] OrderBikeDto b)
        {
            OrderBike.AddOrderBike(b);
        }
        //put-עדכון
        // PUT api/<BikeController1>/5

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderBikeDto b)
        {
            OrderBike.UpdateOrderBike(b, id);
        }
        //delete-מחיקה
        // DELETE api/<BikeController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OrderBike.DeleteOrderBike(id);
        }
    }
}
