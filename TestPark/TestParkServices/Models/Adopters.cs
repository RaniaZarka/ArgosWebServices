using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestParkServices.Models
{
    public class Adopters
    {
        private int _pId;
        private string _username;
        private string _password;



        public Adopters(int pId, string username, string password)
        {
            _pId = pId;
            _username = username;
            _password = password;
        }

        public int PId
        {
            get { return _pId; }
           set  { _pId = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}