using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Users.Queries.GetByUserEmailToken;
public class GetByUserEmailTokenQuery:UserForLoginDto, IRequest<AccessToken>
{
    public class GetByUserEmailTokenQueryHandler : IRequestHandler<GetByUserEmailTokenQuery, AccessToken>
    {
        private readonly IUserRepository _userRepository;
         private readonly ITokenHelper _tokenHelper;
         private readonly UserBusinessRules _userBusinessRules;
        public GetByUserEmailTokenQueryHandler(IUserRepository userRepository, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<AccessToken> Handle(GetByUserEmailTokenQuery request, CancellationToken cancellationToken)
        {
            var userExist =  _userBusinessRules.UserEmailCanNotBeDuplicatedWhenInserted(request.Email);
            
             

            throw new Exception();
        }
    }
}