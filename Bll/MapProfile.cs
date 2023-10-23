﻿using AutoMapper;
using Entity2;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Bike,BikeDto>();
            CreateMap<BikeDto, Bike>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Opinion, OpinionDto>();
            CreateMap<OpinionDto, Opinion>();


            CreateMap<Station, StationDto>();
            CreateMap<StationDto, Station>();
           // .ForMember(x => x.custName, y => y.MapFrom(z => z.IdCustNavigation.Name))

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();



            CreateMap<OrderBike, OrderBikeDto>();
            CreateMap<OrderBikeDto, OrderBike>();
            //
        }
    }
}
