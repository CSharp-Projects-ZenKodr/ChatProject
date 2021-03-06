﻿using System;
using System.Linq;

namespace Communication
{
    [Serializable]
    public class Request : Message
    {
        protected Net.Action _action;
        public Net.Action Action { get => _action; set => _action = value; }

        public Request() { }

        public Request(Net.Action action)
        {
            _action = action;
        }

        public override string ToString()
        {
            return "[" + _action + "]";
        }
    }

    [Serializable]
    public class Demand : Request
    {
        private readonly string _title;
        public string Title { get => _title; }

        public Demand(Net.Action action, string title) : base(action)
        {
            _title = title;
        }

        public override string ToString()
        {
            return "[" + _action + "] " + _title;
        }
    }

    [Serializable]
    public class UserMsg : Request
    {
        private readonly string _username;
        private readonly string _password;

        public string Username { get => _username; }
        public string Password { get => _password; }

        public UserMsg(Net.Action action, string username, string password) : base(action)
        {
            _action = action;
            _username = username;
            _password = password;
        }

        public override string ToString()
        {
            return ("[" + _action + "] Username: " + _username + " - Password: " + string.Concat(Enumerable.Repeat("*", _password.Length)));
        }
    }
}
