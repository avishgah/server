using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;

namespace Bll
{
     public interface IStationViewBll
    {
        void AddStation(StationViewDto b);

        List<StationViewDto> GetStationList();

        void DeleteStation(int id);
        void UpdateStation(StationViewDto b, int ID);
        StationViewDto GetStation(int id);
    }
}
