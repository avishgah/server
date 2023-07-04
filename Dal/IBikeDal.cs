using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;


namespace Dal
{
    public interface IBikeDal
    {
        void AddBike(Bike b);

        List<Bike> GetBikeList();
        void DeleteBike(int id);
        void UpdateBike(Bike b, int id);
        Bike GetBike(int id);

    }
}
