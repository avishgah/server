using Dto;
using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface IStationBikeView
    {
        void AddStationBikeView(StationBikeViewDto b);

        List<StationBikeViewDto> GetStationBikeViewList();

        void DeleteStationBikeView(int id);
        void UpdateStationBikeView(StationBikeViewDto b, int ID);
        StationBikeViewDto GetStationBikeView(int id);
    }
}
