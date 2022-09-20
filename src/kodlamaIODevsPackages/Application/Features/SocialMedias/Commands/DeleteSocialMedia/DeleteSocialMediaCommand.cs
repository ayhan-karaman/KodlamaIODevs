using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommand : IRequest<string>, ISecuredRequest
    {
        public int SocialMediaId { get; set; }
        public string[] Roles { get; }  = { "User" };

        class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, string>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;
            public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }
            public async Task<string> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(x => x.Id == request.SocialMediaId);
                await _socialMediaBusinessRules.CheckIfYouHaveSocialMedia(socialMedia!);
                SocialMedia deletedSocialMedia = await _socialMediaRepository.DeleteAsync(socialMedia!);
                return "Deleted Social Media";
                
            }
        }

    }
}