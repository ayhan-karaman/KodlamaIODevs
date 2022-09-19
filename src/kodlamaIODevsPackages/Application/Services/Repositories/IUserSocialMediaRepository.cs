using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface ISocialMediaRepository: IAsyncRepository<SocialMedia>, IRepository<SocialMedia>
    {
        
    }
}