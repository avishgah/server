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
        public string AddUser(CustomerDto b)
        {
           CustomerList=mapper.Map<List<CustomerDto>>(UserDal.GetUserList());
            for(var i=0; i<CustomerList.Count; i++)
            {
                if (CustomerList[i].Tz == b.Tz || CustomerList[i].Mail == b.Mail)
                {
                    return "Existing user";
                }
            }
            this.UserDal.AddUser(mapper.Map<Customer>(b));
            return "good";
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
