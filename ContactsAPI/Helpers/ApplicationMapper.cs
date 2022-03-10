using AutoMapper;
using ContactsAPI.Data;
using ContactsAPI.Models;

namespace ContactsAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Contacts, ContactModel>().ReverseMap();
        }
    }
}
