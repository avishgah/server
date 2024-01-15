using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public interface ICustomerOrdersViewDal
    {
        void AddCustomerOrders(CustomerOrdersView b);

        List<CustomerOrdersView> GetCustomerOrdersList();
        void DeleteCustomerOrders(int id);
        void UpdateCustomerOrders(CustomerOrdersView b, int id);
        CustomerOrdersView GetCustomerOrders(int id);
    }
}   
