using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.SocialMedias.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }
        public async Task SocialMediaNameCanNotBeDuplicatedWhenInserted(string SocialMediaName)
        {
          SocialMedia? result = await _socialMediaRepository.GetAsync(sm => sm.SocialMediaName == SocialMediaName);
         if(result != null) throw new BusinessException("Social media name exists");
        }
        public async Task CheckIfYouHaveSocialMedia(SocialMedia socialMedia)
        {
            SocialMedia? result = await _socialMediaRepository.GetAsync(sm => sm.Id == socialMedia.Id);
            if(result == null) throw new BusinessException("Social media not found");
        }
        
    }
}