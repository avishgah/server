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
        void AddOrder(Order b);
        List<Order> GetOrderList();
        void DeleteOrder(int id);
        void UpdateOrder(Order b, int id);
        Order GetOrder(int id);
    }
}
