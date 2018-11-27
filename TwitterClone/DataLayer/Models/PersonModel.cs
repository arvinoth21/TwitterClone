using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{

    public class PersonModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public System.DateTime Joined { get; set; }
        public bool active { get; set; }
        public int TweetCount { get; set; }
        public int FollowingCount { get; set; }
        public int FollowersCount { get; set; }

        public virtual ICollection<FollowingModel> Followings { get; set; }
        public virtual ICollection<FollowingModel> Followings1 { get; set; }
        public virtual ICollection<TweetModel> Tweet1 { get; set; }
    }
    public class FollowingModel
    {
        public string UserId { get; set; }
        public int FollowingId { get; set; }
    }
}

