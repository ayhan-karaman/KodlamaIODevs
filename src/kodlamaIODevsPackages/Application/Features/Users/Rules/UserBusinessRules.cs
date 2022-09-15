using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;

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
    public async void CheckIfUserExists(string email)
    {
         var result = await _userRepository.GetAsync(user => user.Email == email);
         if(result is  null) throw new BusinessException("Email address exists");
    }


    public void CheckIfThePasswordIsCorrect(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        if(!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
            throw new BusinessException("Please make sure you entered your password correctly");
    }

}