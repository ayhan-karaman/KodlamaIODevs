using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology;
public class DeleteTechnologyCommand: IRequest<DeletedTechnologyDto>
{
    public int Id { get; set; }
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology? technology = await _technologyRepository.GetAsync(x => x.Id == request.Id);
            _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);
            Technology deletedTechnology = await _technologyRepository.DeleteAsync(technology);

            DeletedTechnologyDto mappedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
            return mappedTechnologyDto;
        }
    }
}