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
   public class BikeBll : IBikeBll
    {
        IBikeDal BikeDal;

         IMapper mapper;

        public BikeBll(IBikeDal b, IMapper m)
        {
            BikeDal = b;
            mapper = m;
        }
        public void AddBike(BikeDto b)
        {
            this.BikeDal.AddBike(mapper.Map<Bike>(b));
        }

        public void DeleteBike(int id)
        {
            this.BikeDal.DeleteBike(id);
        }

        public BikeDto GetBike(int id)
        {
           return mapper.Map<BikeDto>( this.BikeDal.GetBike(id));
        }

        public List<BikeDto> GetBikeList()
        {
           return mapper.Map<List<BikeDto>>(BikeDal.GetBikeList());
        }

        public void UpdateBike(BikeDto b, int ID)
        {
            BikeDal.UpdateBike(mapper.Map<Bike>( b), ID);
        }
    }
}
