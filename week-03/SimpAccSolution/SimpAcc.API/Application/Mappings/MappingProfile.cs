using AutoMapper;
using SimpAcc.API.Application.DTOs;
using SimpAcc.API.Domain.Models;

namespace SimpAcc.API.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, ViewContactDTO>();
        }
    }
}
