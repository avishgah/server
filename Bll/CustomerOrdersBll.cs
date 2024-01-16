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
    public class CustomerOrdersBll:ICustomerOrdersBll
    {
        ICustomerOrdersViewDal CustomerOrdersDal;

        IMapper mapper;

        public CustomerOrdersBll(ICustomerOrdersViewDal b, IMapper m)
        {
            CustomerOrdersDal = b;
            mapper = m;
        }
        public void AddCustomerOrders(CustomerOrdersViewDto b)
        {
            this.CustomerOrdersDal.AddCustomerOrders(mapper.Map<CustomerOrdersView>(b));
        }

        public void DeleteCustomerOrders(int id)
        {
            this.CustomerOrdersDal.DeleteCustomerOrders(id);
        }

        public CustomerOrdersViewDto GetCustomerOrders(int id)
        {
            return mapper.Map<CustomerOrdersViewDto>(this.CustomerOrdersDal.GetCustomerOrders(id));
        }

        public List<CustomerOrdersViewDto> GetCustomerOrdersList()
        {
            return mapper.Map<List<CustomerOrdersViewDto>>(CustomerOrdersDal.GetCustomerOrdersList());
        }

        public void UpdateCustomerOrders(CustomerOrdersViewDto b, int ID)
        {
            CustomerOrdersDal.UpdateCustomerOrders(mapper.Map<CustomerOrdersView>(b), ID);
        }
    }
}
