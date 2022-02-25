using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSystem
{
    class GlobalVar
    {
        private static string _userID = "";
        private static string _userName = "";
        private static string _firstName = "";
        private static string _lastName = "";
        private static DateTime _currentDate;
        private static string _pathFolder = "";
        private static string _pathReport = "";
        private static string _serverName = "";
        private static string _database = "";
        private static string _sqlUserID = "";
        private static string _sqlPassword = "";
        private static string _pUser = "";
        private static string _userStatus = "";


        public static string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public static string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public static string PUser
        {
            get { return _pUser; }
            set { _pUser = value; }
        }
        public static string UserStatus
        {
            get { return _userStatus; }
            set { _userStatus = value; }
        }

        public static string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public static string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public static DateTime CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }

        public static string PathFolder
        {
            // get { return @"c:\OHFile\"; }
            get { return _pathFolder; }
            set { _pathFolder = value; }
        }
        public static string PathReport
        {
            get { return _pathReport; }
            set { _pathReport = value; }
        }

        public static string ServerName
        {

            get { return _serverName; }
            set { _serverName = value; }
        }
        public static string Database
        {
            get { return _database; }
            set { _database = value; }
        }

        public static string SqlUserID
        {
            get { return _sqlUserID; }
            set { _sqlUserID = value; }
        }

        public static string SqlPassword
        {
            get { return _sqlPassword; }
            set { _sqlPassword = value; }
        }

    }
}
