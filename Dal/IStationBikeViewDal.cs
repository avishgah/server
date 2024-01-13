using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IStationBikeViewDal
    {
        void AddStationBikeView(StationBikeView b);

        List<StationBikeView> GetStationBikeViewList();
        void DeleteStationBikeView(int id);
        void UpdateStationBikeView(StationBikeView b, int id);
        StationBikeView GetStationBikeView(int id);
    }
}
