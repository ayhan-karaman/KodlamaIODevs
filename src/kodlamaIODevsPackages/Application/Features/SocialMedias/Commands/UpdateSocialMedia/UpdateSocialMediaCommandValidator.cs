using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandValidator:AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaCommandValidator()
        {
            RuleFor(x => x.Url).NotEmpty().Must(StartWithUrlName!);
        }
        private bool StartWithUrlName(string arg)
        {
            return arg.StartsWith("http://") || arg.StartsWith("https://");
        }
    }
}