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
    public class SocialMediaRepository : EfRepositoryBase<SocialMedia, BaseDbContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(BaseDbContext context) : base(context)
        {
        }
    }
}