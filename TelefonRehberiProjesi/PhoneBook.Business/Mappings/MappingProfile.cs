using AutoMapper;
using PhoneBook.Core.Dtos;
using PhoneBook.Core.Entities;

namespace PhoneBook.Business.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Contact, ContactDto>().ReverseMap();
    }
}