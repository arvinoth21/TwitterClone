using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class HomeViewModel
    {
        public List<string> PersonToFollow { get; set; }
        public List<TweetModel> Tweets { get; set; }
        public PersonModel PersonDetail { get; set; }

    }
}