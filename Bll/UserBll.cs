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
        public void AddUser(CustomerDto b)
        {

            this.UserDal.AddUser(mapper.Map<Customer>(b));
        }

        public void DeleteUser(int id)
        {
            this.UserDal.DeleteUser(id);
        }

        public CustomerDto GetUser(int id)
        {
            return mapper.Map<CustomerDto>(this.UserDal.GetUser(id));
        }

        public List<CustomerDto> GetUserList()
        {
            
            return mapper.Map<List<CustomerDto>>(UserDal.GetUserList());
        }

        public void UpdateUser(CustomerDto b, int ID)
        {
            UserDal.UpdateUser(mapper.Map<Customer>(b), ID);
        }
    }
}
