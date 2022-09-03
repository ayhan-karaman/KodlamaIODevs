using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Rules;
public  class LanguageBusinessRules
{
    private readonly ILanguageRepository _languageRepository;

    public LanguageBusinessRules(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }
    public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
    {
         IPaginate<Language> result = await _languageRepository.GetListAsync(lng => lng.Name == name);
         if(result.Items.Any()) throw new BusinessException("Language name exists");
    }

    public void LanguageShouldExistWhenRequested(Language language)
    {
        if(language is null) throw new BusinessException("Requested language does not exist");
    }
}