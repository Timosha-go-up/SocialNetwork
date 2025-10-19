using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class User
    {
        // Свойства (публичный доступ для чтения/записи)
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string FavoriteMovie { get; set; }
        public string FavoriteBook { get; set; }

        // Списки сообщений (можно модифицировать)
        public List<Message> IncomingMessages { get; private set; }
        public List<Message> OutgoingMessages { get; private set; }

        // Конструктор
        public User(
            string firstName,
            string lastName,
            string email,
            string password,
            string photo = null,
            string favoriteMovie = null,
            string favoriteBook = null,
            IEnumerable<Message> incomingMessages = null,
            IEnumerable<Message> outgoingMessages = null
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Photo = photo ?? string.Empty;
            FavoriteMovie = favoriteMovie ?? "Не указано";
            FavoriteBook = favoriteBook ?? "Не указано";
            IncomingMessages = (incomingMessages?.ToList()) ?? new List<Message>();
            OutgoingMessages = (outgoingMessages?.ToList()) ?? new List<Message>();
        }

        // Внутренний метод для репозитория (назначение Id)
        internal void SetId(int id) => Id = id;
    }




}
