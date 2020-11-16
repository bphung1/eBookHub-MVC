using System;
using System.Collections.Generic;

namespace eBookHub.DataAccess.Entities
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int DiscussionId { get; set; }
        public int LoginId { get; set; }
        public string CommentString { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual Discussion Discussion { get; set; }
        public virtual Account Login { get; set; }
    }
}
