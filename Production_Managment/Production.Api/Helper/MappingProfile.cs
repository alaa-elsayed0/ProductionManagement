using AutoMapper;
using Production.Core.DataTransferObject;
using Production.Core.Entities;

namespace Production.Api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductPlanning, ProductPlanningDto>()
                .ForMember(d => d.ProductName , o => o.MapFrom(s => s.Product.Name));
            CreateMap<Tracking, TrackingDto>().ReverseMap();
            CreateMap<StopRecords, StopRecordsDto>().ReverseMap();
            CreateMap<ProductionOperation, ProductionOperationsDto>().ReverseMap();
        }
    }
}
