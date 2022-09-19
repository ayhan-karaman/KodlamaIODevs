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

namespace Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommand : IRequest<CreatedSocialMediaDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public string SocialMediaName { get; set; }
        public string[] Roles { get; } = {"User"};

        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusiness;
            public CreateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusiness)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusiness = socialMediaBusiness;
            }
            public async Task<CreatedSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _socialMediaBusiness.SocialMediaNameCanNotBeDuplicatedWhenInserted(request.SocialMediaName);

                var mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                var createdSocialMediaDto = await _socialMediaRepository.AddAsync(mappedSocialMedia);
                var mappedSocialMediaDto = _mapper.Map<CreatedSocialMediaDto>(createdSocialMediaDto);
                return mappedSocialMediaDto;
            }
        }
    }
}