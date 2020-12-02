﻿using System;
using System.Linq;

namespace Communication
{
    public interface User
    {
        string ToString();
    }

    [Serializable]
    public class NewUser : User
    {
        private String _username;
        private String _password;

        public string Username { get => _username; }
        public string Password { get => _password; }

        public NewUser(String username, String password)
        {
            _username = username;
            _password = password;
        }

        public override string ToString()
        {
            return ("Username: " + _username + " - Password: " + string.Concat(Enumerable.Repeat("*", _password.Length)));
        }
    }

    [Serializable]
    public class StatusUser : User
    {
        private bool _error;
        private string _message;

        public bool Error { get => _error; }
        public string Message { get => _message; }

        public StatusUser(bool error, string message)
        {
            _error = error;
            _message = message;
        }

        public override string ToString()
        {
            return ((_error ? "Success: " : "Error: ") + _message);
        }
    }
}
