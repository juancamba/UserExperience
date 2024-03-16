using AutoMapper;
using UserExperience.Dto;
using UserExperience.Models;

namespace UserExperience.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<UserCreate, User>();

        }
    }
}
