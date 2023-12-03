using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
namespace Dal
{
    public interface IOrderBikeDal
    {
        void AddOrderBike(OrderBike b);

        List<OrderBike> GetOrderBikeList();
        List<OrderBike> GetOrderBikeListByIdList(int id);

        void DeleteOrderBike(int id);
        void UpdateOrderBike(OrderBike b, int id);
        OrderBike GetOrderBike(int id);
    }
}
