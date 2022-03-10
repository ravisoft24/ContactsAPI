using AutoMapper;
using PropertyAPI.Data;
using PropertyAPI.Models;

namespace PropertyAPI.Helpers
{
    public class ApplicationMapper : Profile 
    {
        public ApplicationMapper()
        {
            CreateMap<Property, PropertyModel>().ReverseMap();
        }
    }
}
