using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;

namespace Dal
{
    public class OrderDal : IOrderDal
    {
        private readonly BikeARContext context;

        public OrderDal(BikeARContext con)
        {
            context = con;
        }

        public int AddOrder(Order b, int count)
        {
            b.DateOrder = DateTime.Now;
            int countBIkesAreOrder = context.OrderBikes.Count(x => x.IdPayNavigation.IdStation == b.IdStation && (x.Status == false && x.IdPayNavigation.DateOrder > DateTime.Now.AddMinutes(-30) || x.Status == true && x.DateEnd == null));
            int countBikes = context.Bikes.Count(x => x.IdStation == b.IdStation && !x.OrderBikes.Any(y => y.DateEnd != null));
            if (countBikes - countBIkesAreOrder < count)
            {
                return -1;
            }
            else
            {

                for (int i = 0; i < count; i++)
                {
                    b.OrderBikes.Add(new OrderBike() { Status = false });
                }
                context.Orders.Add(b);
                context.SaveChanges();
                return b.Id;
            }
        }

        public void DeleteOrder(int id)
        {
            Order order = this.context.Orders.FirstOrDefault(x => x.Id == id);
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public Order GetOrder(int id)
        {
            return this.context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetOrderList()
        {
            return context.Orders.ToList();
        }

        public void UpdateOrder(Order b, int id)
        {
            Order or = this.context.Orders.FirstOrDefault(x => x.Id == id);
            or.DatePay = b.DatePay;
            or.DateOrder = b.DateOrder;
            or.IdStation = b.IdStation;
            or.Code = b.Code;
            or.IsPay = b.IsPay;
            or.IdCust = b.IdCust;
            or.EndSum = b.EndSum;
            context.SaveChanges();
        }
    }
}
