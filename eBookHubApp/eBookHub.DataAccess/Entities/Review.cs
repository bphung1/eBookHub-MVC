using System;
using System.Collections.Generic;

namespace eBookHub.DataAccess.Entities
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int BookId { get; set; }
        public int LoginId { get; set; }
        public int Rating { get; set; }
        public string ReviewString { get; set; }

        public virtual Books Book { get; set; }
        public virtual Account Login { get; set; }
    }
}
