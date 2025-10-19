using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services.UserServices;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork
{
    // Создаем отдельный класс для работы с тестовыми данными
    
    public class TestDataInitializer
    {
        private readonly IUserRepository _userRepository;

        public TestDataInitializer(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void InitializeTestUsers()
        {
            try
            {
                var registrationService = new UserRegistrationService(_userRepository);
                var testUsers = GetTestUserList();

                foreach (var userData in testUsers)
                {
                    if (_userRepository.FindByEmail(userData.Email) == null)
                    {
                        registrationService.Register(userData);
                        Console.WriteLine($"Пользователь {userData.Email}\t{userData.Password}\tдобавлен");
                    }
                    else
                    {
                        Console.WriteLine($"Пользователь {userData.Email} уже существует");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при инициализации тестовых пользователей: {ex.Message}");
            }
        }

        private List<UserRegistrationData> GetTestUserList()
        {
            return [
                new() {
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
            new UserRegistrationData
            {
                FirstName = "Алексей",
                LastName = "Петров",
                Email = "Alex@example.com",
                Password = "5432677888"
            }
            ];
        }
    }

}
