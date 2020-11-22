using eBookHub.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookHub.DataAccess
{
    public static class Mapper
    {
        public static Account Map(Entities.Account account) => new Account
        {
            LoginID = account.LoginId,
            DisplayName = account.DisplayName,
            Username = account.DisplayName,
            Email = account.EmailAddress,
            AboutMe = account.AboutMe,
            Admin = (bool)account.Administrator,
            UpcomingBook = account.UpcomingBooks
        };

        public static Entities.Account Map(Account account) => new Entities.Account
        {
            LoginId = account.LoginID,
            DisplayName = account.DisplayName,
            UserName = account.Username,
            EmailAddress = account.Email,
            AboutMe = account.AboutMe,
            Administrator = account.Admin,
            UpcomingBooks = account.UpcomingBook
        };

    }
}
