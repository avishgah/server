using Dto;

namespace Bll
{
    public interface IuserBll
    {

        CustomerDto AddUser(CustomerDto b);
        CustomerDto GetUserByTz(string id);
        List<CustomerDto> GetUserList();
        CustomerDto GetUserAndPassword(string id, string pas);
        CustomerDto GetUserByMail(string mail);
        void ChangePassword(CustomerDto user);
        void DeleteUser(int id);
        void UpdateUser(CustomerDto b, int ID);
        CustomerDto GetUser(int id);

    }
}
