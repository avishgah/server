using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
namespace Dal
{
    public class OrderBikeDal : IOrderBikeDal
    {
        private readonly BikeARContext context;
        
        public OrderBikeDal(BikeARContext con)
        {
            context = con;
        }

        public void AddOrderBike(OrderBike b)
        {
            context.OrderBikes.Add(b);
            context.SaveChanges();
        }

        public void DeleteOrderBike(int id)
        {
            OrderBike OrderBike = this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
            context.OrderBikes.Remove(OrderBike);
            context.SaveChanges();
        }

        public OrderBike GetOrderBike(int id)
        {
            return this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
        }

        public List<OrderBike> GetOrderBikeList()
        {
            return context.OrderBikes.ToList();
        }

        public void UpdateOrderBike(OrderBike b, int id)
        {
            OrderBike OrderBike = this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
            OrderBike.IdBike=b.IdBike;
            OrderBike.IdPay=b.IdPay;
            OrderBike.IdStation=b.IdStation;
            OrderBike.Status = b.Status;
            OrderBike.Sum=b.Sum;
            OrderBike.DateOrder=b.DateOrder;
            OrderBike.DateStart=b.DateStart;
            OrderBike.DateEnd=b.DateEnd;
            context.SaveChanges();
        }
    }
}
