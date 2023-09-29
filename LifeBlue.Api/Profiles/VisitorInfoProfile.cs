using AutoMapper;
using LifeBlue.Core.Models;
using LifeBlue.Dal.DTO;

namespace LifeBlue.Api.Profiles
{
    public class VisitorInfoProfile : Profile
    {
        public VisitorInfoProfile()
        {
            CreateMap<VisitorRequest, VisitorInformation>()
                .ReverseMap();
        }
    }
}
