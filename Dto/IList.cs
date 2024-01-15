using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public interface IList
    {
        public List<OrderDto> Lst { get; set; }
        public List<OrderBikeDto> Lst3 { get; set; }
    }
}
