using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommand : IRequest<CreatedUserSocialMediaDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public string SocialMediaName { get; set; }
        public string[] Roles { get; } = {"User"};

        public class CreateUserSocialMediaCommandHandler : IRequestHandler<CreateUserSocialMediaCommand, CreatedUserSocialMediaDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaBusinessRules _userSocialMediaBusiness;
            public CreateUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules userSocialMediaBusiness)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _userSocialMediaBusiness = userSocialMediaBusiness;
            }
            public async Task<CreatedUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaBusiness.SocialMediaNameCanNotBeDuplicatedWhenInserted(request.SocialMediaName);

                var mappedUserSocialMedia = _mapper.Map<UserSocialMedia>(request);
                var createdUserSocialMediaDto = await _userSocialMediaRepository.AddAsync(mappedUserSocialMedia);
                var mappedUserSocialMediaDto = _mapper.Map<CreatedUserSocialMediaDto>(createdUserSocialMediaDto);
                return mappedUserSocialMediaDto;
            }
        }
    }
}