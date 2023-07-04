using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
namespace Dal
{
    public interface IOpinionDal
    {

        void AddOpinion(Opinion b);

        List<Opinion> GetOpinionList();
        void DeleteOpinion(int id);
        void UpdateOpinion(Opinion b, int id);
        Opinion GetOpinion(int id);
    }
}
