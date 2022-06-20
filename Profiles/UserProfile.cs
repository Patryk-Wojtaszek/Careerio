using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Dtos;
using Careerio.Authentication;
using AutoMapper;

namespace Careerio.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
