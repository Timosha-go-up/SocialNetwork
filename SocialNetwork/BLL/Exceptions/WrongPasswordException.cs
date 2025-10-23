using System;
using System.Runtime.Serialization;

namespace SocialNetwork.BLL.Exceptions
{

    public class WrongPasswordException : Exception
    {
        // Константы для стандартных сообщений
        private const string DefaultMessage = "Неверный пароль";
        private const string AttemptMessage = "Попытка входа с неверным паролем для пользователя {0}";
        private const string AttemptWithEmailMessage = "Попытка входа с неверным паролем для email {0}";

        // Конструктор по умолчанию
        public WrongPasswordException()
            : base(DefaultMessage)
        {
        }

        // Конструктор с сообщением
        public WrongPasswordException(string message)
            : base(message)
        {
        }

       

       

        // Расширенный конструктор
        public WrongPasswordException(string email, string message)
            : base(string.Format("{0}. {1}", AttemptWithEmailMessage, message))
        {
        }
    }

}