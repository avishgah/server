﻿using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class BikeDal : IBikeDal
    {
        private readonly BikeARContext context;

        public BikeDal(BikeARContext con)
        {
            context = con;
        }
        public void AddBike(Bike b)
        {
            List<Bike> lst = GetBikeList();
            int lastBikeId = lst.Count > 0 ? lst[lst.Count - 1].Id : -1;
            b.Id = lastBikeId+1;  
            b.DateStart = DateTime.Now;
            b.Battery = 100;
            context.Bikes.Add(b);
            context.SaveChanges();
        }

        public void DeleteBike(int id)
        {
            Bike bike = this.context.Bikes.FirstOrDefault(x => x.Id == id);
            context.Bikes.Remove(bike);
            context.SaveChanges();
        }

        public Bike GetBike(int id)
        {
            return this.context.Bikes.FirstOrDefault(x => x.Id == id);
        }

        public List<Bike> GetBikeList()
        {
            return context.Bikes.ToList();
        }

        public void UpdateBike(Bike b, int ID)
        {
            Bike bike = this.context.Bikes.FirstOrDefault(x => x.Id == ID);
            bike.DateStart = b.DateStart;
            bike.IdStation = b.IdStation;
            bike.Battery = b.Battery;
            bike.Code = b.Code;
            bike.Status = b.Status;
            context.SaveChanges();
        }
    }
}
