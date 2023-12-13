using Dto;
using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface IContactBll
    {
        void AddContact(ContactDto b);

        List<ContactDto> GetContactList();

        void DeleteContact(int id);
        void UpdateContact(ContactDto b, int ID);
        ContactDto GetContact(int id);
    }
}
