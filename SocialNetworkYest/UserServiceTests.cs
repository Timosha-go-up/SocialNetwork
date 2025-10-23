using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetworkYest
  
{
    using Xunit;
    using Moq;
    using System;

    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<MessageService> _mockMessageService;
        private UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMessageService = new Mock<MessageService>();
            _userService = new UserService(                                
            );
        }

        [Fact]
        public void Authenticate_UserNotFound_ThrowsException()
        {
            // Подготовка тестовых данных
            var testEmail = "nonexistent@example.com";
            var authData = new UserAuthenticationData
            {
                Email = testEmail,
                Password = "any-password"
            };

            // Настройка мок-объекта
            _mockUserRepository
                .Setup(repo => repo.FindByEmail(testEmail))
                .Returns(null as UserEntity);

            // Проверка исключения
            Assert.Throws<UserNotFoundException>(() =>
                _userService.Authenticate(authData));
        }       
    }
}