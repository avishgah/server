using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using Dal;
using Entity2;


namespace Bll
{
    public class UserBll : IuserBll
    {
        IUserDal UserDal;

        IMapper mapper;

        public UserBll(IUserDal b, IMapper m)
        {
            UserDal = b;
            mapper = m;
        }
        List<CustomerDto> CustomerList;

        public CustomerDto AddUser(CustomerDto b)
        {
            var userList = mapper.Map<List<CustomerDto>>(UserDal.GetUserList());

            // Check if Tz or Mail already exists in the user list
            foreach (var customer in userList)
            {
                if (customer.Tz == b.Tz || customer.Mail == b.Mail)
                {
                    return null; // Indicates Tz or Mail already exists, preventing addition
                }
            }

            // If Tz and Mail are unique, proceed to add the user
            return mapper.Map<CustomerDto>(this.UserDal.AddUser(mapper.Map<Customer>(b)));
        }

        public void DeleteUser(int id)
        {
            this.UserDal.DeleteUser(id);
        }

        public CustomerDto GetUser(int id)
        {
            return mapper.Map<CustomerDto>(this.UserDal.GetUser(id));
        }
        public CustomerDto GetUserByMail(string mail)
        {
            return mapper.Map<CustomerDto>(this.UserDal.GetUserByMail(mail));
        }

        public CustomerDto GetUserByTz(string id)
        {
            return mapper.Map<CustomerDto>(this.UserDal.GetUserByTz(id));
        }

        public CustomerDto GetUserAndPassword(string id,string pas)
        {
           return mapper.Map<CustomerDto>(UserDal.GetUserAndPassword(id,pas));
        }


        public List<CustomerDto> GetUserList()
        {
            
            return mapper.Map<List<CustomerDto>>(UserDal.GetUserList());
        }
        public void ChangePassword(CustomerDto user)
        {
            UserDal.ChangePassword(mapper.Map<Customer> (user));
        }

        public void UpdateUser(CustomerDto b, int ID)
        {
            UserDal.UpdateUser(mapper.Map<Customer>(b), ID);
        }
    }
}
