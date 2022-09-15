using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class UserSocialMedia : Entity
    {
        public int UserId { get; set; }
        public string SocialMediaName { get; set; }
        public string Url { get; set; }
        public virtual User? User { get; set; }

        public UserSocialMedia()
        {
            
        }
        public UserSocialMedia(int id, int userId, string socialMediaName, string url):this()
        {
            Id = id;
            UserId = userId;
            SocialMediaName = socialMediaName;
            Url = url;
        }
    }
}