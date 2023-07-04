using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
using Dto;

namespace Bll
{
    public interface IuserBll
    {

        void AddUser(CustomerDto b);

        List<CustomerDto> GetUserList();
        void DeleteUser(int id);
        void UpdateUser(CustomerDto b, int ID);
        CustomerDto GetUser(int id);

    }
}
