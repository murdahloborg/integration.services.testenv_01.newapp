using AutoMapper;
using Ecco.Integrations.WebService.Model.Dto;
using Ecco.Integrations.WebService.Model.Internal;

namespace Ecco.Integrations.WebService.Converters
{
    public sealed class TargetProductProfile : Profile
    {
        public TargetProductProfile()
        {
            CreateMap<Product, TargetProduct>(MemberList.None)
              .ForMember(d => d.ExternalId, c => c.MapFrom(s => s.Id))
              .ForMember(d => d.Name, c => c.MapFrom(s => s.Name));
        }
    }
}
