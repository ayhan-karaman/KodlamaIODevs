using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.LoginUser;
public class LoginUserQuery: IRequest<AccessToken>
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AccessToken>
    {
        private readonly IUserRepository _userRepository;
         private readonly ITokenHelper _tokenHelper;
         private readonly UserBusinessRules _userBusinessRules;
         private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public LoginUserQueryHandler(IUserRepository userRepository, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _userBusinessRules = userBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
        }
        public async Task<AccessToken> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            User? user =  await _userRepository.GetAsync(x => x.Email == request.Email);
           _userBusinessRules.CheckIfUserExists(user.Email);
           _userBusinessRules.CheckIfThePasswordIsCorrect(request.Password, user.PasswordHash, user.PasswordSalt);

           var userClaims = await _userOperationClaimRepository.GetListAsync(
            x => x.UserId == user.Id,
            include:x => x.Include(cl => cl.OperationClaim),
            cancellationToken: cancellationToken
           );
            
           var token = _tokenHelper.CreateToken(user, userClaims.Items.Select(x => x.OperationClaim).ToList());

            return token;
        }
    }
}