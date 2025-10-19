using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace SocialNetwork.DAL.Repositories
{

    // Реализация репозитория пользователей, объединяющая работу с БД и бизнес‑логикой
    public class UserRepository : BaseRepository, IUserRepository
    {
        // Словарь для хранения пользователей в оперативной памяти (бизнес‑модель User)
        private readonly Dictionary<int, User> _users = new();

        // Счётчик для генерации уникальных Id при добавлении новых пользователей
        private int _nextId = 1;

        // Методы для работы с базой данных (используют UserEntity — DTO для БД)

        /// <summary>
        /// Сохраняет нового пользователя в БД
        /// </summary>
        /// <param name="userEntity">Объект пользователя для сохранения</param>
        /// <returns>Количество затронутых строк (обычно 1 при успехе)</returns>
        public int Create(UserEntity userEntity)
        {
            return Execute(@"INSERT INTO users (firstname, lastname, password, email, photo, favorite_movie, favorite_book)
                       VALUES (:firstname, :lastname, :password, :email, :photo, :favorite_movie, :favorite_book)", userEntity);
        }

        /// <summary>
        /// Получает всех пользователей из БД
        /// </summary>
        /// <returns>Коллекция всех пользователей в виде UserEntity</returns>
        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>("SELECT * FROM users");
        }

        /// <summary>
        /// Находит пользователя по email
        /// </summary>
        /// <param name="email">Email для поиска</param>
        /// <returns>UserEntity найденного пользователя или null, если не найден</returns>

        // Попробуйте явно указать тип параметра
       
        public UserEntity FindByEmail(string email)
        {
            var result = QueryFirstOrDefault<dynamic>(
                "SELECT * FROM users WHERE email = @email",
                new { email });

            if (result == null) return null;

            return new UserEntity
            {
                Id = result.id,
                FirstName = result.firstName,
                LastName = result.lastName,
                Email = result.email,
                Password = result.password,
                Photo = result.photo,
                FavoriteMovie = result.favoriteMovie,
                FavoriteBook = result.favoriteBook
            };
        }





        /// <summary>
        /// Находит пользователя по Id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns>UserEntity найденного пользователя или null, если не найден</returns>
        public UserEntity FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>(
                "SELECT * FROM users WHERE id = :id_p", new { id_p = id });
        }

        /// <summary>
        /// Обновляет данные пользователя в БД
        /// </summary>
        /// <param name="userEntity">Обновлённый объект пользователя</param>
        /// <returns>Количество затронутых строк (обычно 1 при успехе)</returns>
        public int Update(UserEntity userEntity)
        {
            return Execute(@"UPDATE users SET
                       firstname = :firstname,
                       lastname = :lastname,
                       password = :password,
                       email = :email,
                       photo = :photo,
                       favorite_movie = :favorite_movie,
                       favorite_book = :favorite_book
                       WHERE id = :id", userEntity);
        }

        /// <summary>
        /// Удаляет пользователя из БД по Id
        /// </summary>
        /// <param name="id">Id удаляемого пользователя</param>
        /// <returns>Количество затронутых строк (обычно 1 при успехе)</returns>
        public int DeleteById(int id)
        {
            return Execute("DELETE FROM users WHERE id = :id_p", new { id_p = id });
        }

        // Методы для работы с бизнес‑моделью (User — объект приложения)

        /// <summary>
        /// Добавляет нового пользователя в локальное хранилище (память)
        /// Генерирует Id автоматически
        /// </summary>
        /// <param name="user">Объект пользователя</param>
        /// <exception cref="ArgumentNullException">Если user == null</exception>
        /// <exception cref="InvalidOperationException">Если Id уже существует</exception>
        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Генерируем уникальный Id для нового пользователя
            user.SetId(_nextId++);

            // Проверяем, что Id ещё не занят (защита от коллизий)
            if (_users.ContainsKey(user.Id))
                throw new InvalidOperationException($"Пользователь с Id={user.Id} уже существует.");

            // Сохраняем пользователя в словарь по сгенерированному Id
            _users[user.Id] = user;
        }

        /// <summary>
        /// Получает пользователя из локального хранилища по Id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns>Объект User или null, если не найден</returns>
        public User GetById(int id) => _users.GetValueOrDefault(id);
    }







    // Интерфейс репозитория — определяет контракт для работы с пользователями
    public interface IUserRepository
    {
        // Методы для взаимодействия с БД (через UserEntity)

        /// <summary>
        /// Создать запись пользователя в БД
        /// </summary>
        int Create(UserEntity userEntity);

        /// <summary>
        /// Найти пользователя по email в БД
        /// </summary>
        UserEntity FindByEmail(string email);

        /// <summary>
        /// Получить всех пользователей из БД
        /// </summary>
        IEnumerable<UserEntity> FindAll();

        /// <summary>
        /// Найти пользователя по Id в БД
        /// </summary>
        UserEntity FindById(int id);

        /// <summary>
        /// Обновить данные пользователя в БД
        /// </summary>
        int Update(UserEntity userEntity);

        /// <summary>
        /// Удалить пользователя из БД по Id
        /// </summary>
        int DeleteById(int id);

        // Методы для работы с бизнес‑моделью приложения (User)

        /// <summary>
        /// Добавить пользователя в локальное хранилище с автогенерацией Id
        /// </summary>
        void Add(User user);

        /// <summary>
        /// Получить пользователя из локального хранилища по Id
        /// </summary>
        User GetById(int id);
    }
}
