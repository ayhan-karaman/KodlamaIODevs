using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Rules;
public class TechnologyBusinessRules
{
    private readonly ITechnologyRepository _technologyRepository;

    public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }
     public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
    {
         IPaginate<Technology> result = await _technologyRepository.GetListAsync(lng => lng.Name == name);
         if(result.Items.Any()) throw new BusinessException("Language name exists");
    }

     public void TechnologyShouldExistWhenRequested(Technology technology)
    {
        if(technology is null) throw new BusinessException("Requested language does not exist");
    }
}