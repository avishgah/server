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

                    //Bike bike=context.Bikes.FirstOrDefault(x=>x.IdStation == b.IdStation && x.Status==true);
                    b.OrderBikes.Add(new OrderBike() { Status = false,Sum=0 });
                    //  bike.Status = false;
                    context.SaveChanges();
                }
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
            return this.context.Orders.Where(x => x.IdCust == cust.Id).ToList();
        }


        //public List<Order> ReturnOrderByTzCust(string id)
        //{
        //    Customer cust = this.context.Customers.FirstOrDefault(x => x.Tz == id);
        //    List<Order> lst = new List<Order>();

        //    lst= this.context.Orders.Where(x => x.IdCust == cust.Id && x.IsPay!=true).ToList();

        //    List<OrderBike> lst2 = new List<OrderBike>();
        //    lst2=this.context.OrderBikes.Where(x=>x.IdPay==)

        //    foreach(Order bike in lst)
        //    {
        //        if()
        //    }

        //}


        public List<Order> GetOrderByIdCustNotDone(string id)
        {
            double sum = 0;
            List<Order> lst = new List<Order>();
            List<Order> lst2 = new List<Order>();
            Order o;
            Customer cust = this.context.Customers.FirstOrDefault(x => x.Tz == id);

            lst = this.context.Orders.Where(x => x.IdCust == cust.Id && x.IsPay != true).ToList();

            foreach (var item in lst)
            {
                sum = 0;

                //calac minute
                DateTime datestart = item.DateOrder.Value;
                Console.WriteLine(datestart);
                DateTime dateend = DateTime.Now;
                Console.WriteLine(dateend);
                TimeSpan span = dateend.Subtract(datestart);


                double day = span.Days;
                Console.WriteLine(day);
                double minute = span.Minutes;
                Console.WriteLine(minute);
                double houres = span.Hours + (day * 24);
                sum += ((houres * 60) + minute);
                //
                if (sum >= 30)
                {
                    //List<OrderBike> lsto = null;
                    //lsto = this.context.OrderBikes.Where(x => x.IdPay == item.Id).ToList();
                    //foreach (var item2 in lsto)
                    //{
                    //    item2.Status = false;
                    //    Bike bike = this.context.Bikes.FirstOrDefault(x => x.Id == item2.IdBike);
                    //    bike.Status = true;
                    //    context.SaveChanges();
                    //}
                    //delete order?
                    //item.IdCust = null;
                    //item.IdStation = null;
                }
                else
                {
                    lst2.Add(item);
                }

            }
            return lst2;

        }

        public List<Order> GetOrderList()
        {
            return context.Orders.ToList();
        }

        public double UpdateEndSumOfOrder(string id)
        {
            List<Order> lst = new List<Order>();
            List<OrderBike> lst2 = new List<OrderBike>();
            Order o;
            Customer cust = this.context.Customers.FirstOrDefault(x => x.Tz == id);
            lst = this.context.Orders.Where(x => x.IdCust == cust.Id && x.IsPay != true).ToList();
            double sum = 0;
            double Endsum = 0;
            foreach (Order b in lst)
            {

                lst2 = this.context.OrderBikes.Where(x => x.IdPay == b.Id).ToList();

                foreach (OrderBike c in lst2)
                {
                    sum += (double)c.Sum;
                }

                b.EndSum = sum;
                b.IsPay = true;
                b.DatePay=DateTime.Now;
                context.SaveChanges();
                Endsum += sum;
                sum = 0;
            }

            return Endsum;

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
