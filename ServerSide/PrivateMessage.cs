﻿using System;
using Communication;

namespace ServerSide
{
    public partial class Server
    {
        private partial class Receiver
        {
            private void PrivateMessage()
            {
                Console.WriteLine("Sending back user list");

                UserListMsg connected = new UserListMsg();
                foreach (User user in userList)
                {
                    if (user.Comm != null && user.Username != _currentUser.Username)
                    {
                        connected.Usernames.Add(user.Username);
                    }
                }
                
                Net.sendMsg(comm.GetStream(), connected);

                if (connected.Usernames.Count <= 0) return;

                Demand demand = (Demand)Net.rcvMsg(comm.GetStream());

                User buddy = null;
                foreach (User user in userList)
                {
                    if (user.Username.Equals(demand.Title))
                    {
                        buddy = user;
                        break;
                    }
                }

                Console.WriteLine("Private message with " + buddy.Username);

                while (true)
                {
                    Chat chat = (Chat)Net.rcvMsg(comm.GetStream());
                    Console.WriteLine(chat);
                    Net.sendMsg(buddy.Comm.GetStream(), chat);
                }
            }
        }
    }
}