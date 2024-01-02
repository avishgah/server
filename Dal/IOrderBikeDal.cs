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
        TimeSpan CalcTime(int id);
        double CalcSum(int id);
        List<OrderBike> GetOrderBikeList();
        List<OrderBike> GetOrderBikeListByIdList(int id);

        List<OrderBike> ReturnListBikeByIdOrder(int id);

        List<OrderBike> HistoryDrive(string id);

        List<TimeSpan> GetListDateOfUse(string Id);

        void DeleteOrderBike(int id);
        OrderBike UpdateOrderBike(OrderBike b, int id);
        OrderBike GetOrderBike(int id);
    }
}
