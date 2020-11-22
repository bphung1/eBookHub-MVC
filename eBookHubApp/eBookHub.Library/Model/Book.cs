using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBookHub.Library.Model
{
    public class Book
    {
        private string _bookTitle;
        private string _summary;
        private string _content;
        private int _publishLevel;

        public int BookID { get; set; }

        [Required]
        public int GenreID { get; set; }
        public int LoginID { get; set; }

        [Required]
        public string BookTitle
        {
            get => _bookTitle;
            set 
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Book title cannot be empty.", nameof(value));
                }
                _bookTitle = value;
            }
        }

        public int BookVersion { get; set; }
        public DateTime PublicDate { get; set; }

        [Required]
        public string Summary
        {
            get => _summary;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Summary cannot be null", nameof(value));
                }
                _summary = value;
            }
        }

        [Required]
        public int PublishLevel
        {
            get => _publishLevel;
            set
            {
                if (value <= 0 || value > 3)
                {
                    throw new ArgumentException("Publish level must be between 1 and 3", nameof(value));
                }
                _publishLevel = value;
            }
        }

        [Required]
        public string BookContent
        {
            get => _content;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must have content for a book to be a book.", nameof(value));
                }
                _content = value;
            }
        }

        public bool Visibility { get; set; }

        public Genre BookGenre { get; set; } = new Genre();

        public Account BookAccount { get; set; }

        public Discussion BookDiscussion { get; set; }

        public Review BookReview { get; set; }

    }
}
