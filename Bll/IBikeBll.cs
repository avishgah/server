using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
using Dto;

namespace Bll
{
    public interface IBikeBll
    {
        void AddBike(BikeDto b);

        List<BikeDto> GetBikeList();
        void DeleteBike(int id);
        void UpdateBike(BikeDto b, int ID);
        BikeDto GetBike(int id);
    }
}
