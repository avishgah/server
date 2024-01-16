using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CustomerOrdersViewDal:ICustomerOrdersViewDal
    {
        private readonly BikeARContext context;

        public CustomerOrdersViewDal(BikeARContext con)
        {
            context = con;
        }
        public void AddCustomerOrders(CustomerOrdersView b)
        {
           
            context.CustomerOrdersViews.Add(b);
            context.SaveChanges();
        }

        public void DeleteCustomerOrders(int id)
        {
            CustomerOrdersView CustomerOrders = this.context.CustomerOrdersViews.FirstOrDefault(x => x.Id == id);
            context.CustomerOrdersViews.Remove(CustomerOrders);
            context.SaveChanges();
        }

        public CustomerOrdersView GetCustomerOrders(int id)
        {
            return this.context.CustomerOrdersViews.FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerOrdersView> GetCustomerOrdersList()
        {
            return context.CustomerOrdersViews.ToList();
        }

        public void UpdateCustomerOrders(CustomerOrdersView b, int ID)
        {
            CustomerOrdersView CustomerOrders = this.context.CustomerOrdersViews.FirstOrDefault(x => x.Id == ID);
            CustomerOrders.NumOrders = b.NumOrders;
            CustomerOrders.Status = b.Status;
            CustomerOrders.DateBirth = b.DateBirth;
            CustomerOrders.Address = b.Address;
            CustomerOrders.Phon= b.Phon;    
            CustomerOrders.Mail = b.Mail;
            CustomerOrders.Name = b.Name;
            CustomerOrders.Pic = b.Pic;
            CustomerOrders.Toun = b.Toun;
            CustomerOrders.Tz = b.Tz;
            context.SaveChanges();
        }
    }
}
