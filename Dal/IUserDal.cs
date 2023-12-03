using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;

namespace Dal
{
    public interface IUserDal
    {
        void AddUser(Customer b);

        List<Customer> GetUserList();
        Customer GetUserAndPassword(string id, string pas);
        void DeleteUser(int id);
        void UpdateUser(Customer b, int id);
        Customer GetUser(int id);
        Customer GetUserByTz(string id);
    }
}
