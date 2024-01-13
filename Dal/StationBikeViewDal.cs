using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class StationBikeViewDal:IStationBikeViewDal
    {
        private readonly BikeARContext context;

        public StationBikeViewDal(BikeARContext con)
        {
            context = con;
        }
        public void AddStationBikeView(StationBikeView b)
        {

            context.StationBikeViews.Add(b);
            context.SaveChanges();
        }

        public void DeleteStationBikeView(int id)
        {
            StationBikeView StationBikeView = this.context.StationBikeViews.FirstOrDefault(x => x.Id == id);
            context.StationBikeViews.Remove(StationBikeView);
            context.SaveChanges();
        }

        public StationBikeView GetStationBikeView(int id)
        {
            return this.context.StationBikeViews.FirstOrDefault(x => x.Id == id);
        }

        public List<StationBikeView> GetStationBikeViewList()
        {
            return context.StationBikeViews.ToList();
        }

        public void UpdateStationBikeView(StationBikeView b, int ID)
        {
            StationBikeView stationBikeView = this.context.StationBikeViews.FirstOrDefault(x => x.Id == ID);
            stationBikeView.Battery=b.Battery; stationBikeView.Status=b.Status;
            stationBikeView.DateStart=b.DateStart;
            stationBikeView.IdStation=b.IdStation;
            stationBikeView.Name=b.Name;
            stationBikeView.Location=b.Location;
            context.SaveChanges();
        }
    }
}

