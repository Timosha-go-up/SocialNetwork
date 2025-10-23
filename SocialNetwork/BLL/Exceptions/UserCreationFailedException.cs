using SocialNetwork.BLL.Models;
using System;
using System.Runtime.Serialization;

namespace SocialNetwork.BLL.Exceptions
{
    

    public class UserCreationFailedException : Exception
    {
        public UserRegistrationData UserData { get; }

        public UserCreationFailedException(UserRegistrationData userData)
            : base("Ошибка создания пользователя")
        {
            UserData = userData;
        }
    }


}