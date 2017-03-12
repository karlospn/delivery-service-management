using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using delivery.management.webui.ViewModels;

namespace delivery.management.webui.Models
{
    public static class AutoMapperModelConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<OrderViewModelProfile>();          
            });

        }
    }

    internal class OrderViewModelProfile : Profile
    {
        public OrderViewModelProfile()
        {
            base.CreateMap<OrderViewModel, RegisterOrderModel>().ReverseMap();
        }

    }

}
