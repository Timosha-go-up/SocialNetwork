using SocialNetwork.BLL.Models;
using System;

namespace SocialNetwork.BLL.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Пользователь не найден") { }
        public UserNotFoundException(string message) : base(message) { }


 }


    }
