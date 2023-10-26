using Entity2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class OpinionDal : IOpinionDal
    {
        private readonly BikeARContext context;

        public OpinionDal(BikeARContext con)
        {
            context = con;
        }

        public void AddOpinion(Opinion b)
        {

            context.Opinions.Add(b);
            context.SaveChanges();
        }

        public void DeleteOpinion(int id)
        {

            Opinion opinion = this.context.Opinions.FirstOrDefault(x => x.Id == id);
            context.Opinions.Remove(opinion);
            context.SaveChanges();
        }

        public Opinion GetOpinion(int id)
        {
            return this.context.Opinions.FirstOrDefault(x => x.Id == id);
        }

        public List<Opinion> GetOpinionList()
        {
            return context.Opinions.ToList();
        }

        public void UpdateOpinion(Opinion b, int id)
        {
            Opinion opinion = this.context.Opinions.FirstOrDefault(x => x.Id == id);
            opinion.Caption = b.Caption;
            opinion.IdStationNavigation = b.IdStationNavigation;
            //opinion.na= b.IdNavigation;
            opinion.IdCust = b.IdCust;
            opinion.IdStation= b.IdStation;
            opinion.SatisfactionLeve = b.SatisfactionLeve;
            context.SaveChanges();
        }
    }
}
