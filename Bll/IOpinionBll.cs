using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity2;
using Dto;


namespace Bll
{
    public interface IOpinionBll
    {
        void AddOptinion(OpinionDto b);

        List<OpinionDto> GetOptinionList();
        void DeleteOptinion(int id);
        void UpdateOptinion(OpinionDto b, int ID);
        OpinionDto GetOptinion(int id);
    }
}
