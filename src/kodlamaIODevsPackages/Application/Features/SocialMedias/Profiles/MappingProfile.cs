using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.UserSocialMedias.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             CreateMap<SocialMedia, CreatedSocialMediaDto>().ReverseMap(); 
             CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
             CreateMap<SocialMedia, UpdatedSocialMediaDto>().ReverseMap();
        }
    }
}