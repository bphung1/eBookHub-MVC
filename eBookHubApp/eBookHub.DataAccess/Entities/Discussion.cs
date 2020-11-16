using System;
using System.Collections.Generic;

namespace eBookHub.DataAccess.Entities
{
    public partial class Discussion
    {
        public Discussion()
        {
            Comment = new HashSet<Comment>();
        }

        public int DiscussionId { get; set; }
        public int BookId { get; set; }
        public string Topic { get; set; }

        public virtual Books Book { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
