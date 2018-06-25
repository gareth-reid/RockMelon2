using System.Collections.Generic;
using Rockmelon.Repository.Entities;

namespace RockMelon.Site.Models
{
    public class FeedbackModel
    {
        public int? PageId { get; set; }
        public IEnumerable<Feedback> FeedbackItems { get; set; }
    }
}