using AutoMapper;
using ThisIsMyProve.Core.DTOs.SliderDtos;
using ThisIsMyProve.Core.Entities.HomePageEntities;

namespace ThisIsMyProve.API.AutoMapDto
{
    public class GeneralProfiles : Profile
    {
        public GeneralProfiles()
        {
            CreateMap<Slider,ListSliderDto>().ReverseMap();
        }
    }
}
