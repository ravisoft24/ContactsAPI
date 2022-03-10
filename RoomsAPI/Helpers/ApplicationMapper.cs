using AutoMapper;
using RoomsAPI.Data;
using RoomsAPI.Models;

namespace RomomsAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Rooms, RoomModel>().ReverseMap();
        }
    }
}
