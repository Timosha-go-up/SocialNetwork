using Moq;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkYest
{
    public class RegisterTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<MessageService> _mockMessageService;
        private UserService _userService;

        public RegisterTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMessageService = new Mock<MessageService>();
            _userService = new UserService(
            );
        }

        [Fact]
        public void Validation_ExistingEmail_ThrowsException()
        {
          
            var userRegistrationData = new UserRegistrationData
            {
                Email = "existing@example.com"
            };

           
            var existingUser = new UserEntity
            {
                email = userRegistrationData.Email
            };

          
            _mockUserRepository
             .Setup(repo => repo.FindByEmail(userRegistrationData.Email))
             .Returns(existingUser);

           
            Assert.Throws<ValidationException>(() =>
                _userService.Validation(userRegistrationData));
        }

        [Fact]
        public void Validation_InvalidEmail_ThrowsException()
        {
           
            var userRegistrationData = new UserRegistrationData
            {
                Email = "invalid-email"
            };

            
            Assert.Throws<ValidationException>(() =>
             _userService.Validation(userRegistrationData));
        }
        
    }
}
