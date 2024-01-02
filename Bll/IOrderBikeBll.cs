using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
using Dto;

namespace Bll
{
    public interface IOrderBikeBll
    {
        void AddOrderBike(OrderBikeDto b);
        List<OrderBikeDto> GetOrderBikeListByIdList(int id);
        List<OrderBikeDto> ReturnListBikeByIdOrder(int id);

        List<OrderBikeDto> HistoryDrive(string id);
        List<TimeSpan> GetListDateOfUse(string Id);
        TimeSpan CalcTime(int id);
        double CalcSum(int id);
        List<OrderBikeDto> GetOrderBikeList();
        void DeleteOrderBike(int id);
        OrderBikeDto UpdateOrderBike(OrderBikeDto b, int ID);
        OrderBikeDto GetOrderBike(int id);
    }
}
