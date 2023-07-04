using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dto;
using Dal;
using Entity2;

namespace Bll
{
    public class StationBll : IStattionBll
    {
        IStationDal StationDal;

        IMapper mapper;

        public StationBll(IStationDal b, IMapper m)
        {
            StationDal = b;
            mapper = m;
        }
        
        public void AddStation(StationDto b)
        {
            this.StationDal.AddStation(mapper.Map<Station>(b));
        }

        public void DeleteStation(int id)
        {
            this.StationDal.DeleteStation(id);
        }

        public StationDto GetStation(int id)
        {

            return mapper.Map<StationDto>(this.StationDal.GetStation(id));
        }

        public List<StationDto> GetStationList()
        {
            return mapper.Map<List<StationDto>>(StationDal.GetStationList());
        }

        public void UpdateStation(StationDto b, int ID)
        {
            StationDal.UpdateStation(mapper.Map<Station>(b), ID);
        }
    }
}
