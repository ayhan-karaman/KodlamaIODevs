using FluentValidation;

namespace Application.Features.Users.Queries.LoginUser;
public class LoginUserQueryValidator:AbstractValidator<LoginUserQuery>
{
    public LoginUserQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
    }
}