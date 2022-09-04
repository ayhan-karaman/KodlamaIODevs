using FluentValidation;

namespace Application.Features.Languages.Commands.CreateLanguage;
public class CreateLanguageCommandValidator:AbstractValidator<CreateLanguageCommand>
{
    public CreateLanguageCommandValidator()
    {
        RuleFor(lng => lng.Name).NotEmpty();
        RuleFor(lng => lng.Name).MinimumLength(2);
    }
}