using System;
using System.Collections.Generic;
using System.Text;

namespace eBookHub.Library.Model
{
    public class Comment
    {
        private string _text;

        public int CommentID { get; set; }

        public int DiscussionID { get; set; }

        public string Text 
        {
            get => _text;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must leave comment.", nameof(value));
                }
                _text = value;
            }
        }

        public DateTime TimeStamp { get; set; }

        public int LoginID { get; set; }

        public Account CommentAccount { get; set; }

    }
}
