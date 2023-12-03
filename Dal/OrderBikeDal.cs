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

        public List<OrderBike> GetOrderBikeListByIdList(int id)
        {
            return this.context.OrderBikes.Where(x => x.IdPay == id).ToList();
        }

        public void GetBike(OrderBike b, int id)
        {
            OrderBike OrderBike = this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
            if (OrderBike != null)
            {
                OrderBike.IdBike = b.IdBike;
                OrderBike.Status = true;
                OrderBike.DateStart =DateTime.Now;
                context.SaveChanges();
            }
        }

        public void SetBike( int id)
        {
            OrderBike OrderBike = this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
            if (OrderBike != null)
            {
               // OrderBike.Sum = b.Sum;
                OrderBike.DateEnd =DateTime.Now;
                context.SaveChanges();
            }
        }

        public void UpdateOrderBike(OrderBike b, int id)
        {
            OrderBike OrderBike = this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
            OrderBike.IdBike=b.IdBike;
            OrderBike.IdPay=b.IdPay;
            OrderBike.Status = b.Status;
            OrderBike.Sum=b.Sum;
            OrderBike.DateStart=b.DateStart;
            OrderBike.DateEnd=b.DateEnd;
            context.SaveChanges();
        }
    }
}
