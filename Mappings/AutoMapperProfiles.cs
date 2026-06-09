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
            
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, RequestUserDTO>().ReverseMap();

            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<Booking, RequestBookingDTO>().ReverseMap();
        }
    }
}
