using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
namespace Dal
{
    public interface IOrderDal
    {
        int AddOrder(Order b, int count);
        List<Order> GetOrderList();
        List<Order> GetOrderByIdCust(string id);
        double UpdateEndSumOfOrder(string id);
        List<Order> GetOrderByIdCustNotDone(string id);

        bool IsExist(int b, int count);
        void DeleteOrder(int id);

        void UpdateOrder(Order b, int id);
        Order GetOrder(int id);
    }
}
