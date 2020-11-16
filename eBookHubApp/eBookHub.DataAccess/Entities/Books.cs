using System;
using System.Collections.Generic;

namespace eBookHub.DataAccess.Entities
{
    public partial class Books
    {
        public Books()
        {
            Discussion = new HashSet<Discussion>();
            Review = new HashSet<Review>();
        }

        public int BookId { get; set; }
        public int GenreId { get; set; }
        public int LoginId { get; set; }
        public string BookTitle { get; set; }
        public int BookVersion { get; set; }
        public DateTime PublishDate { get; set; }
        public string TextOfBook { get; set; }
        public string Summary { get; set; }
        public int PublishLevel { get; set; }
        public bool? Visible { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Account Login { get; set; }
        public virtual ICollection<Discussion> Discussion { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
