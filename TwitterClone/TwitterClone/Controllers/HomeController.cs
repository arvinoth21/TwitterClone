using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class HomeController : Controller
    {
        private TwitterCloneRepository _twitterCloneRepository;
        public ActionResult Index()
        {
            _twitterCloneRepository = new TwitterCloneRepository();
            HomeViewModel vm = new HomeViewModel();

            var userId = Session["UserId"].ToString();
            vm.Tweets = _twitterCloneRepository.GetTweets(userId);
            vm.PersonDetail = _twitterCloneRepository.GetPersonDetail(userId);
            vm.PersonToFollow = _twitterCloneRepository.GetPersontofollow(userId);

            ViewBag.FollowingCount = vm.PersonDetail.FollowingCount;
            ViewBag.FollowersCount = vm.PersonDetail.FollowersCount;
            ViewBag.TweetCount = vm.PersonDetail.TweetCount;
            ViewBag.ProfileName = Session["UserId"].ToString();

            return View(vm);

        }
        public ActionResult DashBoard()
        {
            

            return View();
        }

        public ActionResult Follow(string followId)
        {
            _twitterCloneRepository = new TwitterCloneRepository();

            var userId = Session["UserId"].ToString();
            var twits = _twitterCloneRepository.FollowPerson(userId, followId);


            return RedirectToAction("index");
        }

        public ActionResult Tweet(string message)
        {
            _twitterCloneRepository = new TwitterCloneRepository();

            var userId = Session["UserId"].ToString();
            var twits = _twitterCloneRepository.UpdateTweet(message,userId);


            return RedirectToAction("index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}