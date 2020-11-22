using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBookHub.Library.Model
{
    public class Account
    {
        private string _displayName;
        private string _userName;
        private string _email;
        private string _upcomingBook = "";
        private string _aboutMe = "";

        public int LoginID {get; set;}

        [Required]
        public string DisplayName {
            get => _displayName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Display name cannot be empty", nameof(value));
                }
                _displayName = value;
            }
        }

        [Required]
        public string Username
        {
            get => _userName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Username cannot be empty.", nameof(value));
                }
                _userName = value;
            }
        }

        [Required]
        public string Email
        {
            get => _email;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Email cannot be empty.", nameof(value));
                }
            }
        }

        public string AboutMe
        {
            get => _aboutMe;
            set => _aboutMe = value ?? "";
        }

        public bool Admin { get; set; }

        /// <summary>
        /// Text of upcoming book.
        /// </summary>
        /// <remarks>
        /// Null is treated as equivalant as empty string
        /// </remarks>
        public string UpcomingBook 
        {
            get => _upcomingBook;
            set => value = _upcomingBook ?? "";
        }

        public List<Book> ListOfBookPerAccount { get; set; } = new List<Book>();
    }
}
