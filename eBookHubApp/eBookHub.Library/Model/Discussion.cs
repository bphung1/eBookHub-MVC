using System;
using System.Collections.Generic;
using System.Text;

namespace eBookHub.Library.Model
{
    public class Discussion
    {
        private string _topic;

        public int DiscussionID { get; set; }

        public int BookID { get; set; }

        public string Topic
        {
            get => _topic;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must have topic.", nameof(value));
                }
                _topic = value;
            }
        }
    }
}
