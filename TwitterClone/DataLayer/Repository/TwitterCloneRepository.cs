using DataLayer.DataContext;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class TwitterCloneRepository
    {
        TwitterCloneEntities context;
        public TwitterCloneRepository()
        {
            context = new TwitterCloneEntities();
        }

        public string RegisterUser(PersonModel model)
        {
            try
            {
                Person person = new Person();
                person.UserId = model.UserId;
                person.FullName = model.FullName;
                person.Password = model.Password;
                person.Joined = model.Joined;
                person.Email = model.Email;
                person.active = true;
                context.People.Add(person);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return "Success";
        }


        public List<TweetModel> GetTweets(string userId)
        {
            var result = new List<TweetModel>();

            var followingId = context.Followings.Where(x => x.UserId == userId).Select(x=>x.FollowingId).ToList();
            followingId.Add(userId);

            result = context.Tweets.Where(x => followingId.Contains(x.UserId)).Select(x => new TweetModel
            {
                UserId = x.UserId,
                Message = x.Message,
                TweetId = x.TweetId,
                Created = x.Created,
            }).OrderByDescending(x=>x.Created).ToList();

            return result;
        }

        public PersonModel GetPersonDetail(string userId)
        {
            var result = new PersonModel();

            result = context.People.Where(x => x.UserId == userId && x.active == true).Select(x => new PersonModel
            {
                UserId = x.UserId,
                Email = x.Email,
                Joined = x.Joined,
                FollowersCount = x.Followings.Count(),
                FollowingCount = x.Followings1.Count(),
                TweetCount =  x.Tweets.Count()
            }).FirstOrDefault();

            return result;
        }
        public string UpdateTweet(string message, string userId)
        {
            try
            {
                Tweet tweet = new Tweet();
                tweet.UserId = userId;
                tweet.Message = message;
                tweet.Created = DateTime.Now;
                context.Tweets.Add(tweet);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return "Success";
        }


        public string FollowPerson(string userId, string followId)
        {
            try
            {
                Following follow = new Following();
                follow.UserId = userId;
                follow.FollowingId = followId;
                context.Followings.Add(follow);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return "Success";
        }
        public List<string> GetPersontofollow(string userId)
        {
            return context.Followings.Where(x => x.UserId != userId).Select(x => x.FollowingId).ToList();
        }
        public string GetEmail(string userId)
        {
            return context.People.Where(x => x.UserId == userId).Select(x => x.Email).FirstOrDefault();
        }
    }
}
