using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TweetModel
    {
        public int TweetId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> Created { get; set; }

        public virtual PersonModel Person { get; set; }
    }
}
