using PriceEngine.Models;
using PriceEngine.Data;
using AutoMapper;

namespace PriceEngine.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<PriceEngines, PriceEngineModel>().ReverseMap();
        }
    }
}
