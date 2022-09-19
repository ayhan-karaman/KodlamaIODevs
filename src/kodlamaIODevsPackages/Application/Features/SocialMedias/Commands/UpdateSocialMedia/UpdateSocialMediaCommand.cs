using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaDto>, ISecuredRequest
    {
        public int SocialMediaId { get; set; }
        public string Url { get; set; }
        public string[] Roles { get; } = {"User"};

        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;
            private readonly IMapper _mapper;
            public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, SocialMediaBusinessRules socialMediaBusinessRules, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _socialMediaBusinessRules = socialMediaBusinessRules;
                _mapper = mapper;
            }
            public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? socialMedia = await _socialMediaRepository.GetAsync( x => x.Id == request.SocialMediaId);
                 await _socialMediaBusinessRules.CheckIfYouHaveSocialMedia(socialMedia!);

                 socialMedia!.Url = request.Url!;
                 
                SocialMedia? updateSocialMedia = await _socialMediaRepository.UpdateAsync(socialMedia!);
                var mappedUpdateSocialMediaDto = _mapper.Map<UpdatedSocialMediaDto>(socialMedia);

                return mappedUpdateSocialMediaDto;
            }
        }
    }
}