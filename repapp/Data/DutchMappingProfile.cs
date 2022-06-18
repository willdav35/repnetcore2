using AutoMapper;
using repapp.Data.Entities;
using repapp.ViewModels;

namespace repapp.Data
{
        public class DutchMappingProfile : Profile
        {
            public DutchMappingProfile()
            {
                CreateMap<Order, OrderViewModel>()
                  .ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
                  .ReverseMap();

                CreateMap<OrderItem, OrderItemViewModel>()
                  .ReverseMap();
            }
        }
    }



