using Dto;

namespace Bll
{
    public interface IuserBll
    {

        string AddUser(CustomerDto b);
        CustomerDto GetUserByTz(string id);
        List<CustomerDto> GetUserList();
        CustomerDto GetUserAndPassword(string id, string pas);
        void DeleteUser(int id);
        void UpdateUser(CustomerDto b, int ID);
        CustomerDto GetUser(int id);

    }
}
