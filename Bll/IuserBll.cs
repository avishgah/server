using Dto;

namespace Bll
{
    public interface IuserBll
    {

        CustomerDto AddUser(CustomerDto b);
        CustomerDto GetUserByTz(string id);
        List<CustomerDto> GetUserList();
        CustomerDto GetUserAndPassword(string id, string pas);
        CustomerDto GetMailAndPassword(string id, string mail);
        void SendEmailOnly(string to, string name, string subject, string text);

        CustomerDto GetUserByMail(string mail);
        void ChangePassword(CustomerDto user);
        void DeleteUser(int id);
        void UpdateUser(CustomerDto b, int ID);
        CustomerDto GetUser(int id);

    }
}
