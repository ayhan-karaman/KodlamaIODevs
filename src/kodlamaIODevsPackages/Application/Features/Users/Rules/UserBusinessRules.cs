using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Users.Rules;
public class UserBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
    {
         var result = await _userRepository.GetAsync(user => user.Email == email);
         if(result is not null) throw new BusinessException("Email address exists");
    }

}