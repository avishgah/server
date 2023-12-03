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
    public class StationViewBll:IStationViewBll
    {
        IStationViewDal StationViewDal;

        IMapper mapper;

        public StationViewBll(IStationViewDal b, IMapper m)
        {
            StationViewDal = b;
            mapper = m;
        }
        public void AddStation(StationViewDto b)
        {
            this.StationViewDal.AddStation(mapper.Map<StationView>(b));
        }

        public void DeleteStation(int id)
        {
            this.StationViewDal.DeleteStation(id);
        }

        public StationViewDto GetStation(int id)
        {
            return mapper.Map<StationViewDto>(this.StationViewDal.GetStation(id));
        }

        public List<StationViewDto> GetStationList()
        {
            return mapper.Map<List<StationViewDto>>(StationViewDal.GetStationList());
        }

        public void UpdateStation(StationViewDto b, int ID)
        {
            StationViewDal.UpdateStation(mapper.Map<StationView>(b), ID);
        }
    }
}
