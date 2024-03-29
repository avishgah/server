﻿using Entity2;
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

        public Customer AddUser(Customer b)
        {
            var addedCustomer = context.Customers.Add(b);
            context.SaveChanges();
            return addedCustomer.Entity;
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




        public Customer GetUserByMail(string mail)
        {
            return this.context.Customers.FirstOrDefault(x => x.Mail == mail);
        }

        public Customer GetUserAndPassword(string id, string pas)
        {
            return this.context.Customers.FirstOrDefault(x => x.Tz == id && x.Password == pas);
        }

        public Customer GetMailAndPassword(string pass, string mail)
        {
            return this.context.Customers.FirstOrDefault(x => x.Password == pass && x.Mail == mail);
        }

        public List<Customer> GetUserList()
        {
            return context.Customers.ToList();
        }
        public void ChangePassword(Customer user)
        {
            Customer cust = GetUserByMail(user.Mail);
            if (cust != null)
            {
                cust.Password = user.Password;
                context.SaveChanges();
            }
        }
        public void UpdateUser(Customer b, int id)
        {
            Customer cust = this.context.Customers.FirstOrDefault(x => x.Id == id);

            if (b.Name == "change pic")
            {
                cust.Pic = b.Pic;
                context.SaveChanges();
            }
            else
            {
                if (cust != null)
                {
                    cust.Tz = b.Tz;
                    cust.Name = b.Name;
                    cust.Status = b.Status;
                    cust.IsManager = b.IsManager;
                    cust.Password= b.Password ?? cust.Password;
                    // cust.Orders = b.Orders;
                    cust.Address = b.Address;
                    cust.Mail = b.Mail;
                    //cust.Opinion = b.Opinion;
                    cust.Toun = b.Toun;
                    cust.Pic = b.Pic ?? cust.Pic;
                    cust.Phon = b.Phon;
                    cust.ReadTerms = true;

                    context.SaveChanges();
                }
            }

        }
    }
}
