using System;
using System.Collections.Generic;
using System.Text;

namespace eBookHub.Library.Model
{
    public class Review
    {
        private string _text;
        private int _rating;

        public int ReviewID { get; set; }
        public int BookID { get; set; }
        public int LoginID { get; set; }

        public int Rating
        {
            get => _rating;
            set
            {
                if (value <= 0 || value > 5)
                {
                    throw new ArgumentException("Rating must be between 1 and 5.", nameof(value));
                }
                _rating = value;
            }
        }

        public string Text 
        {
            get => _text;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must provide a review.", nameof(value));
                }
                _text = value;
            }
        }

        public Account ReviewAccount { get; set; }

    }
}
