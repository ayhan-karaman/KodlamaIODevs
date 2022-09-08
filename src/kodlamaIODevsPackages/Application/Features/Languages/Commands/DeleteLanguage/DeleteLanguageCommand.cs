using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage;
public class DeleteLanguageCommand:IRequest<DeletedLanguageDto>
{
    public int Id { get; set; }

    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;
        private readonly IMapper _mapper;
        public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
            _mapper = mapper;
        }
        public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(lng => lng.Id == request.Id);
            _languageBusinessRules.LanguageShouldExistWhenRequested(language);
            language.IsActive = true;
            Language deletedLanguage = await _languageRepository.UpdateAsync(language);
            DeletedLanguageDto deletedLanguageDto =  _mapper.Map<DeletedLanguageDto>(deletedLanguage);
            
            return deletedLanguageDto;
           
        }
    }
}