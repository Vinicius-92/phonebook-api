using AutoMapper;
using PhonebookAPI.Models;
using PhonebookAPI.Models.Dtos;

namespace PhonebookAPI.Profiles
{
    public class PhonebookProfile : Profile
    {
        public PhonebookProfile()
        {
            CreateMap<CreatePersonDto, Person>();
            CreateMap<Person, PersonCreatedResponse>();
        }
    }
}