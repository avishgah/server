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
    public class OrderBll : IOrderBll
    {
        IOrderDal OrderDal;

        IMapper mapper;


        public OrderBll(IOrderDal b, IMapper m)
        {
            OrderDal = b;
            mapper = m;
        }

        public void AddOrder(OrderDto b)
        {
            this.OrderDal.AddOrder(mapper.Map<Order>(b));
        }

        public void DeleteOrder(int id)
        {
            this.OrderDal.DeleteOrder(id);
        }

        public OrderDto GetOrder(int id)
        {
            return mapper.Map<OrderDto>(this.OrderDal.GetOrder(id));
        }

        public List<OrderDto> GetOrderList()
        {
            return mapper.Map<List<OrderDto>>(OrderDal.GetOrderList());
        }

        public void UpdateOrder(OrderDto b, int ID)
        {
            OrderDal.UpdateOrder(mapper.Map<Order>(b), ID);
        }
    }
}
