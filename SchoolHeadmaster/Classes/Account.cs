using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchool.Classes
{
    class Account
    {
        public int Acc_PerId { get; protected set; } = -1;
        public string AccUsername { get; protected set; }
        public string AccPassword { get; protected set; }

        public Account() { }
        public Account(string accUsername, string accPassword)
        {
            AccUsername = accUsername;
            AccPassword = accPassword;
        }
        public Account (int acc_PerId)
        {
            Acc_PerId = acc_PerId;
        }
        public Account(string username)
        {
            AccUsername = username;
        }
    }
}
