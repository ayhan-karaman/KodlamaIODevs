using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommandValidator:AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandValidator()
        {
            RuleFor(x => x.Url).NotEmpty().Must(StartWithUrlName!);
            RuleFor(x => x.SocialMediaName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.UserId).NotEmpty();
        }
        private bool StartWithUrlName(string arg)
        {
            return arg.StartsWith("http://") || arg.StartsWith("https://");
        }
    }
}