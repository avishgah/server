using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class UserDal : IUserDal
    {
        private readonly BikeARContext context;

        public UserDal(BikeARContext con)
        {
            context = con;
        }

        public void AddUser(Customer b)
        {

            context.Customers.Add(b);
            context.SaveChanges();
        }

        public void DeleteUser(int id)
        {

            Customer user = this.context.Customers.FirstOrDefault(x => x.Id == id);
            context.Customers.Remove(user);
            context.SaveChanges();
        }

        public Customer GetUser(int id)
        {
            return this.context.Customers.FirstOrDefault(x => x.Id == id);
        }
        public Customer GetUserByTz(string id)
        {
            return this.context.Customers.FirstOrDefault(x => x.Tz == id);
        }

        public Customer GetUserAndPassword(string id, string pas)
        {
            return this.context.Customers.FirstOrDefault(x => x.Tz == id && x.Password==pas);
        }

        public List<Customer> GetUserList()
        {
            return context.Customers.ToList();
        }

        public void UpdateUser(Customer b, int id)
        {
            Customer cust = this.context.Customers.FirstOrDefault(x => x.Id == id);
            if (cust != null)
            {
                cust.Tz = b.Tz;
                cust.Name = b.Name;
                cust.Status = b.Status;
                cust.IsManager = b.IsManager;
               // cust.Orders = b.Orders;
                cust.Address = b.Address;
                cust.DateBirth = b.DateBirth;
                cust.Mail = b.Mail;
                //cust.Opinion = b.Opinion;
                cust.Toun = b.Toun;
                cust.Pic = b.Pic;
                cust.Phon = b.Phon;
                cust.ReadTerms = b.ReadTerms;

                context.SaveChanges();
            }
        }
    }
}
