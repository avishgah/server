using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;

namespace Dal
{
    public interface IStationDal
    {
        void AddStation(Station b);

        List<Station> GetStationList();
        void DeleteStation(int id);
        void UpdateStation(Station b, int id);
        Station GetStation(int id);

    }
}
