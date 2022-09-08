using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Profiles;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Technology, TechnologyListDto>()
        .ForMember(tch => tch.LanguageName, opt =>opt.MapFrom(tch => tch.Language.Name))
        .ReverseMap();
        CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        CreateMap<Technology, TechnologyGetByIdDto>()
        .ForMember(tch => tch.LanguageName, opt =>opt.MapFrom(tch => tch.Language.Name))
        .ReverseMap();
    }
}