using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repository
{
    public class UserSocialMediaRepository : EfRepositoryBase<UserSocialMedia, BaseDbContext>, IUserSocialMediaRepository
    {
        public UserSocialMediaRepository(BaseDbContext context) : base(context)
        {
        }
    }
}