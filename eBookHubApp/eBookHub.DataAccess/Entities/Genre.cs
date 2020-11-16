using System;
using System.Collections.Generic;

namespace eBookHub.DataAccess.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Books>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
