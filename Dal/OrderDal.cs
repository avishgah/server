using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
using Microsoft.EntityFrameworkCore;


namespace Dal
{
    public class OrderDal : IOrderDal
    {
        private readonly BikeARContext context;

        List<Order> lst = new List<Order>();
        List<OrderBike> lst3 = new List<OrderBike>();

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
                    if (b.Code == "station")
                    {
                        Bike Bike = this.context.Bikes.FirstOrDefault(x => x.Status == true);
                        Console.WriteLine(Bike);
                        Bike.Status = false;

                        b.OrderBikes.Add(new OrderBike() { Status = true, Sum = 0, DateStart = DateTime.Now, IdBike = Bike.Id });

                    }
                    if (b.Code == "web")
                    {
                        b.OrderBikes.Add(new OrderBike() { Status = false, Sum = 0 });
                    }
                    //Bike bike=context.Bikes.FirstOrDefault(x=>x.IdStation == b.IdStation && x.Status==true);
                    //  bike.Status = false;
                    context.SaveChanges();
                }

                b.EndSum = 0;
                b.IsPay = false;
                b.DateOrder = DateTime.Now;
                context.Orders.Add(b);
                context.SaveChanges();
                return b.Id;
            }
        }
        public bool IsExist(int b, int count)
        {
            int countBIkesAreOrder = context.OrderBikes.Count(x => x.IdPayNavigation.IdStation == b && (x.Status == false && x.IdPayNavigation.DateOrder > DateTime.Now.AddMinutes(-30) || x.Status == true && x.DateEnd == null));
            int countBikes = context.Bikes.Count(x => x.IdStation == b && !x.OrderBikes.Any(y => y.DateEnd != null));
            if (countBikes - countBIkesAreOrder < count)
            {
                return false;
            }
            else
            {
                return true;
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

        public List<Order> GetOrderByIdCust(string id)
        {
            Customer cust = this.context.Customers.FirstOrDefault(x => x.Tz == id);
            return this.context.Orders.Where(x => x.IdCust == cust.Id && x.IsPay != true).ToList();
        }


        public List<Order> GetOrderByIdCustNotDone(int id, int stationID)
        {
            DateTime dateend = DateTime.Now;
            return this.context.Orders
                 .Where(x => x.IdCust == id && x.IsPay != true &&
                 dateend.AddMinutes(-30) < x.DateOrder.Value
                 && x.OrderBikes.Any(y => y.DateStart == null))
                 .Include(x => x.OrderBikes).ToList();


        }

        public List<Order> GetOrderList()
        {
            return context.Orders.ToList();
        }

        public double UpdateEndSumOfOrder(string id)
        {
            //List<Order> lst = new List<Order>();
            List<OrderBike> lst2 = new List<OrderBike>();

            Customer cust = this.context.Customers.FirstOrDefault(x => x.Tz == id);
            lst = this.context.Orders.Where(x => x.IdCust == cust.Id && x.IsPay != true).ToList();

            double sum = 0;
            double Endsum = 0;
            foreach (Order b in lst)
            {

                lst3.AddRange(this.context.OrderBikes.Where(x => x.IdPay == b.Id).ToList());
                lst2 = this.context.OrderBikes.Where(x => x.IdPay == b.Id).ToList();
                foreach (OrderBike c in lst2)
                {
                    sum += (double)c.Sum;
                    c.Status = false;
                    context.SaveChanges();
                }

                b.EndSum = sum;
                // b.IsPay = true;
                b.DatePay = DateTime.Now;
                context.SaveChanges();
                Endsum += sum;
                sum = 0;
            }

            return Endsum;

        }


        public void UpdateOrder(Order b, int id)
        {
            if (b.Code == "true")
            {
                Order x = this.context.Orders.FirstOrDefault(x => x.Id == id);
                x.IsPay = true;
            }
            else
            {
                Order or = this.context.Orders.FirstOrDefault(x => x.Id == id);
                or.DatePay = b.DatePay;
                or.DateOrder = b.DateOrder;
                or.IdStation = b.IdStation;
                or.Code = b.Code;
                or.IsPay = b.IsPay;
                or.IdCust = b.IdCust;
                or.EndSum = b.EndSum;
            }

            context.SaveChanges();
        }
    }
}
