using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ContactDal:IContectDal
    {
        private readonly BikeARContext context;

        public ContactDal(BikeARContext con)
        {
            context = con;
        }
        public void AddContact(Contact b)
        {
            b.Date = DateTime.Now;
            context.Contacts.Add(b);
            context.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            Contact Contact = this.context.Contacts.FirstOrDefault(x => x.Id == id);
            context.Contacts.Remove(Contact);
            context.SaveChanges();
        }

        public Contact GetContact(int id)
        {
            return this.context.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public List<Contact> GetContactList()
        {
            return context.Contacts.ToList();
        }

        public void UpdateContact(Contact b, int ID)
        {
            Contact Contact = this.context.Contacts.FirstOrDefault(x => x.Id == ID);

            Contact.Cuption = b.Cuption;
            Contact.Name = b.Name;
            Contact.Email = b.Email;
            Contact.Phon=b.Phon;
            Contact.Type = b.Type;
            Contact.Status = b.Status;
            context.SaveChanges();
        }
    }
}
