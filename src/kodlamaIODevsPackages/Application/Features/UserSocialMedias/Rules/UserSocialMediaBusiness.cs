using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.UserSocialMedias.Rules
{
    public class UserSocialMediaBusinessRules
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;
        public UserSocialMediaBusinessRules(IUserSocialMediaRepository userSocialMediaRepository)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
        }
        public async Task SocialMediaNameCanNotBeDuplicatedWhenInserted(string SocialMediaName)
    {
          UserSocialMedia result = await _userSocialMediaRepository.GetAsync(sm => sm.SocialMediaName == SocialMediaName);
         if(result != null) throw new BusinessException("Social media name exists");
    }
    }
}