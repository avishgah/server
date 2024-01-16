using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface ICustomerOrdersBll
    {
        void AddCustomerOrders(CustomerOrdersViewDto b);

        List<CustomerOrdersViewDto> GetCustomerOrdersList();

        void DeleteCustomerOrders(int id);
        void UpdateCustomerOrders(CustomerOrdersViewDto b, int ID);
        CustomerOrdersViewDto GetCustomerOrders(int id);
    }
}
