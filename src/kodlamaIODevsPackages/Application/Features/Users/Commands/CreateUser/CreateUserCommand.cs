using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;
public class CreateUserCommand:UserForRegisterDto, IRequest<AccessToken>
{
    public class CreateUserCommandCommandHandler : IRequestHandler<CreateUserCommand, AccessToken>
    {
         private readonly IUserRepository _userRepository;
         private readonly ITokenHelper _tokenHelper;
         private readonly IOperationClaimRepository _operationClaimRepository;
         private readonly IUserOperationClaimRepository _userOperationClaimRepository;
         private readonly UserBusinessRules _userBusinessRules;
        public CreateUserCommandCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _operationClaimRepository = operationClaimRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<AccessToken> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserEmailCanNotBeDuplicatedWhenInserted(request.Email);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true,
                AuthenticatorType = AuthenticatorType.Email
            };

            //Calim Name Get
            OperationClaim? claim = await _operationClaimRepository.GetAsync(x => x.Name == "User");
            //Add New User
            User newUser = await _userRepository.AddAsync(user);

            // New Instance UserOperationClaim and Add UserOperationClaim
            UserOperationClaim userOperationClaim = new UserOperationClaim {UserId = newUser.Id, OperationClaimId = claim.Id};
             await _userOperationClaimRepository.AddAsync(userOperationClaim);


            IList<OperationClaim>? claims =  _userRepository.GetClaims(newUser);
            var token = _tokenHelper.CreateToken(newUser, claims);

            return token;
        }

    }
}
