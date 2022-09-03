using Application.Features.Languages.Models;
using Application.Services.Repositories;
using Core.Application.Requests;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Domain.Entities;
using System.Linq;
using System.Text;

namespace Application.Features.Languages.Queries.GetListLanguage;
public class GetListLanguageQuery:IRequest<LanguageListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetListLanguageQueryHadler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

    public GetListLanguageQueryHadler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Language> languages = await _languageRepository.GetListAsync(index: request.PageRequest.Page, size:request.PageRequest.PageSize);
         foreach (var item in languages.Items)
         {
            
         }
        LanguageListModel mappedLanguageListModel = _mapper.Map<LanguageListModel>(languages);
        return mappedLanguageListModel;
    }
    }
}