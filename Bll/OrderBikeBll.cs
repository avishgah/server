﻿using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity2;
using Dal;

namespace Bll
{
    public class OrderBikeBll : IOrderBikeBll
    {

        IOrderBikeDal OrderBikeDal;

        IMapper mapper;

        public OrderBikeBll(IOrderBikeDal b, IMapper m)
        {
            OrderBikeDal = b;
            mapper = m;
        }

        public void AddOrderBike(OrderBikeDto b)
        {
            this.OrderBikeDal.AddOrderBike(mapper.Map<OrderBike>(b));
        }

        public void DeleteOrderBike(int id)
        {
            this.OrderBikeDal.DeleteOrderBike(id);
        }

        public OrderBikeDto GetOrderBike(int id)
        {
            return mapper.Map<OrderBikeDto>(this.OrderBikeDal.GetOrderBike(id));
        }


        public TimeSpan CalcTime(int id)
        {
            return mapper.Map<TimeSpan>(OrderBikeDal.CalcTime(id));
        }
        public double CalcSum(int id)
        {
            return mapper.Map<double>(OrderBikeDal.CalcSum(id));
        }
        public List<OrderBikeDto> GetOrderBikeList()
        {
            return mapper.Map<List<OrderBikeDto>>(OrderBikeDal.GetOrderBikeList());
        }


        public List<OrderBikeDto> ReturnListBikeByIdOrder(int id)
        {
            return mapper.Map<List<OrderBikeDto>>(OrderBikeDal.ReturnListBikeByIdOrder(id));
        }

        public List<OrderBikeDto> GetOrderBikeListByIdList(int id)
        {
            return mapper.Map<List<OrderBikeDto>>(OrderBikeDal.GetOrderBikeListByIdList(id));
        }

        public void UpdateOrderBike(OrderBikeDto b, int ID)
        {

            OrderBikeDal.UpdateOrderBike(mapper.Map<OrderBike>(b), ID);
        }
    }
}
