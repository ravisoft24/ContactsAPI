using AutoMapper;
using ReservationsAPI.Data;
using ReservationsAPI.Models;

namespace ReservationsAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Reservations, ReservationModel>().ReverseMap();
        }

    }
}
