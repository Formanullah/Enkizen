using System.Linq;
using AutoMapper;
using TodoListWeb.API.Dtos;
using TodoListWeb.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          
            CreateMap<UserForRegisterDtos, Users>();
            CreateMap<Users, UserForReturnDtos>()
            .ForMember(dest => dest.RoleName, opt => {
                opt.MapFrom(src => src.Role.RoleName);
            });
            CreateMap<TaskForCreationDtos, Tasks>();
            CreateMap<Users, UserForDetailsDtos>()
             .ForMember(dest => dest.RoleName, opt => {
                opt.MapFrom(src => src.Role.RoleName);
            });
           


        }
        
    }
}