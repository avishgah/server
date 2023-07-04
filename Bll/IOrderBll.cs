using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
using Dto;

namespace Bll
{
    public interface IOrderBll
    {
        void AddOrder(OrderDto b);

        List<OrderDto> GetOrderList();
        void DeleteOrder(int id);
        void UpdateOrder(OrderDto b, int ID);
        OrderDto GetOrder(int id);
    }
}
