using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IContectDal
    {

        void AddContact(Contact b);

        List<Contact> GetContactList();
        void DeleteContact(int id);
        void UpdateContact(Contact b, int id);
        Contact GetContact(int id);

    }
}
