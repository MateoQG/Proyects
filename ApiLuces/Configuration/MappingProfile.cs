using ApiLuces.DTO;
using ApiLuces.Propiedades;
using AutoMapper;
using System.Text.RegularExpressions;

namespace ApiLuces.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MedicionLuces, MedicionLucesDTO>().ReverseMap();
            CreateMap<PatronLuces, PatronLucesDTO>().ReverseMap();
        }
    }
}
