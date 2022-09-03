using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Profiles;
public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
        CreateMap<Language, LanguageListDto>().ReverseMap();
        CreateMap<Language, LanguageGetByIdDto>().ReverseMap();
    }
}