using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Services.UserServices;
using SocialNetwork.BLL.Services.UserServices.Common;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{

    public class AppDependencies
    {
        public IUserRepository UserRepository { get; }
        public IMessageService MessageService { get; }
        public IUserModelFactory UserModelFactory { get; }
        public IFriendModelFactory FriendModelFactory { get; }
        public UserRegistrationService UserRegistrationService { get; }
        public UserAuthenticationService UserAuthenticationService { get; }
        public UserProfileService UserProfileService { get; }
        public FriendService FriendService { get; }

        public AppDependencies()
        {
            // 1. Базовые репозитории и сервисы
            UserRepository = new UserRepository();
            MessageService = new MessageService();

            // 2. Фабрики
            UserModelFactory = new UserModelFactory(MessageService);
            FriendModelFactory = new FriendModelFactory(UserRepository);

            // 3. Сервисы
            UserRegistrationService = new UserRegistrationService(UserRepository);
            UserAuthenticationService = new UserAuthenticationService(UserRepository, UserModelFactory);
            UserProfileService = new UserProfileService(UserRepository, UserModelFactory);
            FriendService = new FriendService(new FriendRepository(),  FriendModelFactory,UserRepository  );
                
              InitializeTestUsers();  
                                 
        }


        private void InitializeTestUsers()
        {
            try
            {
                // Получаем сервис регистрации
                var registrationService = new UserRegistrationService(UserRepository);



                // Создаем тестовых пользователей
                var testUsers = new List<UserRegistrationData>
            {
                new UserRegistrationData
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Email = "ivan@example.com",
                    Password = "12345678"
                },
                new UserRegistrationData
                {
                    FirstName = "Мария",
                    LastName = "Петрова",
                    Email = "maria@example.com",
                    Password = "543211234"
                },
                // Остальные пользователи

                 new UserRegistrationData
                {
                    FirstName = "Алексей",
                    LastName = "Петров",
                    Email = "Alex@example.com",
                    Password = "5432677888"
                }
            };

                foreach (var userData in testUsers)
                {
                    registrationService.Register(userData);
                    Console.WriteLine($"Пользователь {userData.Email} добавлен");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при инициализации тестовых пользователей: {ex.Message}");
            }
        }
    }

}
