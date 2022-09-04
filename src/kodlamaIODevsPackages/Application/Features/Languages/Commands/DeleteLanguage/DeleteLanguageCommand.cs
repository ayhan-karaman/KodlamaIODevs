using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using Core.ElasticSearch.Models;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage;
public class DeleteLanguageCommand:IRequest<ElasticSearchResult>
{
    public int Id { get; set; }

    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand,ElasticSearchResult>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;
        public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
        {
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }
        public async Task<ElasticSearchResult> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(lng => lng.Id == request.Id);
            _languageBusinessRules.LanguageShouldExistWhenRequested(language);
              await _languageRepository.DeleteAsync(language);
            
             return new ElasticSearchResult(true, "Deleted");
           
        }
    }
}