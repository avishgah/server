using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;

namespace Dal
{
    public class StationDal : IStationDal
    {
        private readonly BikeARContext context;

        public StationDal(BikeARContext con)
        {
            context = con;

        }

        public void AddStation(Station b)
        {

            context.Stations.Add(b);
            context.SaveChanges();
        }

        public void DeleteStation(int id)
        {
            Station Station = this.context.Stations.FirstOrDefault(x => x.Id == id);
            context.Stations.Remove(Station);
            context.SaveChanges();
        }

        public Station GetStation(int id)
        {
            return this.context.Stations.FirstOrDefault(x => x.Id == id);
        }

        public List<Station> GetStationList()
        {
            return context.Stations.ToList();
        }

        public void UpdateStation(Station b, int id)
        {
            Station Station = this.context.Stations.FirstOrDefault(x => x.Id == id);
            Station.Id = id;
            Station.Name = b.Name;
            Station.Status = b.Status;
            Station.Location = b.Location;
            Station.Lat = b.Lat;
            Station.Lng = b.Lng;    
            context.SaveChanges();
        }
    }
}
