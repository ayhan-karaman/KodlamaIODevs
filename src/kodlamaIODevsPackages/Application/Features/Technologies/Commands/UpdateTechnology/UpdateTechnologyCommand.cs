using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.UpdateTechnology;
public class UpdateTechnologyCommand:IRequest<UpdatedTechnologyDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LanguageId { get; set; }

    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology? technology = await _technologyRepository.GetAsync(x => x.Id == request.Id);
            _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);
            technology.Name = request.Name;
            technology.LanguageId = request.LanguageId;

            Technology updatedTechnology = await _technologyRepository.UpdateAsync(technology);
            UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
            return updatedTechnologyDto;
        }
    }
}