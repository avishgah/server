using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class StationViewDal:IStationViewDal
    {
        private readonly BikeARContext context;

        public StationViewDal(BikeARContext con)
        {
            context = con;
        }
        public void AddStation(StationView b)
        {

            context.StationViews.Add(b);
            context.SaveChanges();
        }

        public void DeleteStation(int id)
        {
            StationView stat = this.context.StationViews.FirstOrDefault(x => x.Id == id);
            context.StationViews.Remove(stat);
            context.SaveChanges();
        }

        public StationView GetStation(int id)
        {
            return this.context.StationViews.FirstOrDefault(x => x.Id == id);
        }

        public List<StationView> GetStationList()
        {
            return context.StationViews.ToList();
        }

        public void UpdateStation(StationView b, int ID)
        {
            StationView stat = this.context.StationViews.FirstOrDefault(x => x.Id == ID);
            stat.Name=b.Name;
            stat.Lat=b.Lat;
            stat.Lng = b.Lng;
            stat.Id=b.Id;
            stat.Status=b.Status;
            stat.Location=b.Location;   
            stat.Cun=b.Cun;

            context.SaveChanges();
        }
    }
}
