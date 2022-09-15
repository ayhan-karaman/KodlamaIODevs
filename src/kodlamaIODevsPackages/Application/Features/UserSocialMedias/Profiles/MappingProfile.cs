using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedias.Dtos;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.UserSocialMedias.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             CreateMap<UserSocialMedia, CreatedUserSocialMediaDto>().ReverseMap(); 
             CreateMap<UserSocialMedia, CreateUserSocialMediaCommand>().ReverseMap();
        }
    }
}