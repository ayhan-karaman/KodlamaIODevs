using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage;
public class UpdateLanguageCommand:IRequest<UpdatedLanguageDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
         private readonly LanguageBusinessRules _languageBusinessRules;
        public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _languageBusinessRules = languageBusinessRules;
        }
        public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(x => x.Id == request.Id);
             _languageBusinessRules.LanguageShouldExistWhenRequested(language);
             language.Name = request.Name;
             language.IsActive = request.IsActive;
             
             Language updatedLanguage = await _languageRepository.UpdateAsync(language);
             UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguage);
            return updatedLanguageDto;
        }
    }
}