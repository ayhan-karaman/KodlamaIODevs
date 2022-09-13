using FluentValidation;

namespace Application.Features.Users.Commands.CreateUser;
public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).MinimumLength(5);
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
       
    }
}