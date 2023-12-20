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
        int AddOrder(OrderDto b);
        bool IsExist(int b,int count);
        List<OrderDto> GetOrderList();
        List<OrderDto> GetOrderByIdCust(string id);
        List<OrderDto> GetOrderByIdCustNotDone(string id);
        void DeleteOrder(int id);
        void UpdateOrder(OrderDto b, int ID);

        double UpdateEndSumOfOrder(string id);
        OrderDto GetOrder(int id);
    }
}
