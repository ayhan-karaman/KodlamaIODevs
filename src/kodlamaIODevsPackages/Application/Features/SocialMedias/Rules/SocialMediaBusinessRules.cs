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
        private readonly ISocialMediaRepository _SocialMediaRepository;
        public SocialMediaBusinessRules(ISocialMediaRepository SocialMediaRepository)
        {
            _SocialMediaRepository = SocialMediaRepository;
        }
        public async Task SocialMediaNameCanNotBeDuplicatedWhenInserted(string SocialMediaName)
    {
          SocialMedia result = await _SocialMediaRepository.GetAsync(sm => sm.SocialMediaName == SocialMediaName);
         if(result != null) throw new BusinessException("Social media name exists");
    }
    }
}