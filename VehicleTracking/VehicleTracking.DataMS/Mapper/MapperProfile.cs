using AutoMapper;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VehicleModel, VehicleViewModel>()
                .ForMember(m => m.CustomerName, f => f.MapFrom(mf => mf.Customer.Name));
        }
    }
}
