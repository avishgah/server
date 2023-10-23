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

        public void AddOrder(Order b)
        {
           
            context.Orders.Add(b);
            context.SaveChanges();
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
            or.Code = b.Code;
            or.IsPay = b.IsPay;
            or.IdCust = b.IdCust;
            or.EndSum = b.EndSum;
            context.SaveChanges();
        }
    }
}
