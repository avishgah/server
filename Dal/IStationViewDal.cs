using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IStationViewDal
    {
        void AddStation(StationView b);

        List<StationView> GetStationList();
        void DeleteStation(int id);
        void UpdateStation(StationView b, int id);
        StationView GetStation(int id);
    }
}
