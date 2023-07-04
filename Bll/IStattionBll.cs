using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;


namespace Bll
{
    public interface IStattionBll
    {
        void AddStation(StationDto b);

        List<StationDto> GetStationList();
        void DeleteStation(int id);
        void UpdateStation(StationDto b, int ID);
        StationDto GetStation(int id);
    }
}
