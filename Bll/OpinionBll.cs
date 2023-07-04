using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal;
using Entity2;

namespace Bll
{
    public class OpinionBll : IOpinionBll
    {
        IOpinionDal OpinionDal;

        IMapper mapper;

        public OpinionBll(IOpinionDal b, IMapper m)
        {
            OpinionDal = b;
            mapper = m;
        }

        public void AddOptinion(OpinionDto b)
        {
            this.OpinionDal.AddOpinion(mapper.Map<Opinion>(b));
        }

        public void DeleteOptinion(int id)
        {
            this.OpinionDal.DeleteOpinion(id);
        }

        public OpinionDto GetOptinion(int id)
        {
            return mapper.Map<OpinionDto>(this.OpinionDal.GetOpinion(id));
        }

        public List<OpinionDto> GetOptinionList()
        {

            return mapper.Map<List<OpinionDto>>(OpinionDal.GetOpinionList());

        }

        public void UpdateOptinion(OpinionDto b, int ID)
        {
            OpinionDal.UpdateOpinion(mapper.Map<Opinion>(b), ID);
        }
    }
}
