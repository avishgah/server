using AutoMapper;
using Dal;
using Dto;
using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class StationBikeViewBll:IStationBikeView
    {

        IStationBikeViewDal StationBikeViewDal;

        IMapper mapper;

        public StationBikeViewBll(IStationBikeViewDal b, IMapper m)
        {
            StationBikeViewDal = b;
            mapper = m;
        }
        public void AddStationBikeView(StationBikeViewDto b)
        {
            this.StationBikeViewDal.AddStationBikeView(mapper.Map<StationBikeView>(b));
        }

        public void DeleteStationBikeView(int id)
        {
            this.StationBikeViewDal.DeleteStationBikeView(id);
        }

        public StationBikeViewDto GetStationBikeView(int id)
        {
            return mapper.Map<StationBikeViewDto>(this.StationBikeViewDal.GetStationBikeView(id));
        }

        public List<StationBikeViewDto> GetStationBikeViewList()
        {
            return mapper.Map<List<StationBikeViewDto>>(StationBikeViewDal.GetStationBikeViewList());
        }

        public void UpdateStationBikeView(StationBikeViewDto b, int ID)
        {
            StationBikeViewDal.UpdateStationBikeView(mapper.Map<StationBikeView>(b), ID);
        }
    }
}

