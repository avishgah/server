using AutoMapper;
using Dal;
using Dto;
using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class ContactBll:IContactBll
    {
        IContectDal ContactDal;

        IMapper mapper;

        public ContactBll(IContectDal b, IMapper m)
        {
            ContactDal = b;
            mapper = m;
        }
        public void AddContact(ContactDto b)
        {
            this.ContactDal.AddContact(mapper.Map<Contact>(b));
        }

        public void DeleteContact(int id)
        {
            this.ContactDal.DeleteContact(id);
        }

        public ContactDto GetContact(int id)
        {
            return mapper.Map<ContactDto>(this.ContactDal.GetContact(id));
        }

        public List<ContactDto> GetContactList()
        {
            return mapper.Map<List<ContactDto>>(ContactDal.GetContactList());
        }

        public void UpdateContact(ContactDto b, int ID)
        {
            ContactDal.UpdateContact(mapper.Map<Contact>(b), ID);
        }
    }
}
