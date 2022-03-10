using AutoMapper;
using AutoMapper.Features;
using FeaturesAPI.Data;
using FeaturesAPI.Models;

namespace FeaturesAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Features, FeaturesModel>().ReverseMap();
        }


    }
}
