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

        public int AddOrder(OrderDto b)
        {
            //int id = b.Id;
            //b.Id = 0;
            Order order = mapper.Map<Order>(b);
            //order.DateOrder = DateTime.Now;
            //func hoh many can take
           
           return this.OrderDal.AddOrder(order ,b.count);
        }

        public bool IsExist(int b,int count)
        {
            //int id = b.Id;
            //b.Id = 0;
            //Station order = mapper.Map<Station>(b);
            //order.DateOrder = DateTime.Now;
            //func hoh many can take

            return this.OrderDal.IsExist(b, count);
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

        public List<OrderDto> GetOrderByIdCust(string id)
        {
            return mapper.Map<List<OrderDto>>(OrderDal.GetOrderByIdCust(id));
        }
        public List<OrderDto> GetOrderByIdCustNotDone(string id)
        {
            return mapper.Map<List<OrderDto>>(OrderDal.GetOrderByIdCustNotDone(id));
        }

        public void UpdateOrder(OrderDto b, int ID)
        {
            OrderDal.UpdateOrder(mapper.Map<Order>(b), ID);
        }
    }
}
