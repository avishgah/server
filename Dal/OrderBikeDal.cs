using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
using Microsoft.EntityFrameworkCore;

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



        public double CalcSum(int id)
        {
            //דמי שחרור
            double sum = 5;
            OrderBike o = this.context.OrderBikes.FirstOrDefault(x => x.Id == id && x.Status == true);
            if (o != null)
            {
                o.DateEnd = DateTime.Now;
                //int time2 = o.DateStart.Value;
                DateTime datestart = o.DateStart.Value;
                Console.WriteLine(datestart);
                DateTime dateend = DateTime.Now;
                Console.WriteLine(dateend);
                TimeSpan span = dateend.Subtract(datestart);
                Console.WriteLine(span);



                double day = span.Days;
                Console.WriteLine(day);
                double minute = span.Minutes;
                Console.WriteLine(minute);
                double houres = span.Hours + (day * 24);
                sum += ((houres * 60) + minute) * 0.45;

                return sum;
            }
            return 0;
        }
        public List<TimeSpan> GetListDateOfUse(string Id)
        {
            List<TimeSpan> lst = new List<TimeSpan>();
            List<OrderBike> lstOrders = HistoryDrive(Id);


            foreach (OrderBike o in lstOrders)
            {
                DateTime datestart = o.DateStart.Value;
                DateTime dateend = o.DateEnd.Value;
                TimeSpan span = dateend.Subtract(datestart);
                //string formattedTime = $"{(int)span.TotalHours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
                lst.Add(span);
            }
            return lst;
        }
        public TimeSpan CalcTime(int id)
        {
            OrderBike o = this.context.OrderBikes.FirstOrDefault(x => x.Id == id && x.Status == true);
            if (o != null)
            {
                o.DateEnd = DateTime.Now;
                //int time2 = o.DateStart.Value;
                DateTime datestart = o.DateStart.Value;
                DateTime dateend = DateTime.Now;
                TimeSpan span = dateend.Subtract(datestart);

                Console.WriteLine(span);
                return span;
            }
            return TimeSpan.Zero;
        }




        public List<OrderBike> GetOrderBikeList()
        {
            return context.OrderBikes.ToList();
        }

        public List<OrderBike> GetOrderBikeListByIdList(int id)
        {
            List<OrderBike> lst = new List<OrderBike>();
            lst = this.context.OrderBikes.Where(x => x.IdPay == id && x.DateStart == null).ToList();
            return lst;
        }


        public List<OrderBike> ReturnListBikeByIdOrder(int id)
        {
            return this.context.OrderBikes.Where(x => x.IdPay == id && x.DateEnd == null).ToList();
        }

        public List<OrderBike> HistoryDrive(string id)
        {
            Customer cust = this.context.Customers.FirstOrDefault(x => x.Tz == id);
            List<OrderBike> lst3 = new List<OrderBike>();
            if (cust != null)
            {
                List<Order> lst = this.context.Orders.Where(x => x.IdCust == cust.Id && x.IsPay == true).ToList();
                List<OrderBike> lst2 = this.context.OrderBikes.ToList();


                foreach (Order order in lst)
                {
                    foreach (OrderBike item in lst2)
                    {
                        if (item.IdPay == order.Id)
                        {
                            lst3.Add(item);
                        }
                    }
                }
            }
            return lst3;
        }


        public void GetBike(OrderBike b, int id)
        {
            OrderBike OrderBike = this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
            if (OrderBike != null)
            {
                OrderBike.IdBike = b.IdBike;
                OrderBike.Status = true;
                OrderBike.DateStart = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void SetBike(int id)
        {
            OrderBike OrderBike = this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
            if (OrderBike != null)
            {
                // OrderBike.Sum = b.Sum;
                OrderBike.DateEnd = DateTime.Now;
                context.SaveChanges();
            }
        }

        public OrderBike UpdateOrderBike(OrderBike b, int id)
        {

            if (b.Sum == 0 || b.Sum == null)
            {
                Bike Bike = this.context.Bikes.FirstOrDefault(x => x.Status == true);
                Console.WriteLine(Bike);
                Order order = this.context.Orders.Include(x=>x.OrderBikes).FirstOrDefault(x => x.Id == id);
                if (order != null)
                {
                   OrderBike OrderBike= order.OrderBikes.FirstOrDefault(x => x.DateStart == null);
                    OrderBike.IdBike = Bike.Id;
                    OrderBike.Status = true;
                    Bike.Status = false;
                    OrderBike.DateStart = DateTime.Now;
                    context.SaveChanges();
                    return OrderBike;
                }
            }

            else
            {
                OrderBike OrderBike = this.context.OrderBikes.FirstOrDefault(x => x.Id == id);
                Bike bike = this.context.Bikes.FirstOrDefault(x => x.Id == OrderBike.IdBike);
                bike.IdStation = b.IdBike;
                bike.Status = true;
                //OrderBike.IdBike=b.IdBike;
                //OrderBike.IdPay=b.IdPay;
                //OrderBike.Status = false;
                OrderBike.Sum = b.Sum;
                OrderBike.DateEnd = DateTime.Now;
                OrderBike.IdBike = null;
                context.SaveChanges();
                return OrderBike;

            }
            return null;

        }
    }
}
