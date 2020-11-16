using System;
using System.Collections.Generic;

namespace eBookHub.DataAccess.Entities
{
    public partial class Account
    {
        public Account()
        {
            Books = new HashSet<Books>();
            Comment = new HashSet<Comment>();
            Review = new HashSet<Review>();
        }

        public int LoginId { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string AboutMe { get; set; }
        public bool? Administrator { get; set; }
        public string UpcomingBooks { get; set; }

        public virtual ICollection<Books> Books { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
