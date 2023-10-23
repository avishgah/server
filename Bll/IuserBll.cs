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

        string AddUser(CustomerDto b);

        List<CustomerDto> GetUserList();
        CustomerDto GetUserAndPassword(string id, string pas);
        void DeleteUser(int id);
        void UpdateUser(CustomerDto b, int ID);
        CustomerDto GetUser(string id);

    }
}
