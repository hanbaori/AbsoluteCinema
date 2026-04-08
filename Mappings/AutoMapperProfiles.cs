using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Models.DTO;
using AutoMapper;

namespace AbsoluteCinema.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Show, ShowDTO>().ReverseMap();
            CreateMap<Show, RequestShowDTO>().ReverseMap();
        }
    }
}
