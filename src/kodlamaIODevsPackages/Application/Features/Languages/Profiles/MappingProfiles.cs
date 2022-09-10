using Application.Features.Languages.Commands.CreateLanguage;
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
        CreateMap<Language, CreatedLanguageDto>().ReverseMap();
        CreateMap<Language, CreateLanguageCommand>().ReverseMap();
        CreateMap<IPaginate<Language>, LanguageListModel>()
        .ReverseMap();
        CreateMap<Language, LanguageListDto>()
        .ForMember(dest => dest.TechnologyNames, opt=>opt.MapFrom(tch => tch.Technologies.ToList())).ReverseMap();
        CreateMap<Technology, LanguageListDto.TechnologyNameModels>().ReverseMap();

        CreateMap<Language, LanguageGetByIdDto>().ReverseMap();
        CreateMap<Language, DeletedLanguageDto>().ReverseMap();
        CreateMap<Language, UpdatedLanguageDto>().ReverseMap();
    }
}