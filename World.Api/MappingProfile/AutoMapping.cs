using AutoMapper;
using World.Api.DTO.Country;
using World.Api.DTO.Students;
using World.Api.DTO.State;
using World.Api.Model;

namespace World.Api.MappingProfile
{
    public class AutoMapping: Profile
    {
        public AutoMapping() 
        {
            CreateMap<Students, CreateStudentDto>().ReverseMap();
            CreateMap<Students, UpdateStudentDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<State, CreateStateDto>().ReverseMap();
            CreateMap<State, UpdateStateDto>().ReverseMap();
        }

        

    }
}
