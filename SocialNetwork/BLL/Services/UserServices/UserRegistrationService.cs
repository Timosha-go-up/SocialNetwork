using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services.UserServices
{
    public class UserRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserValidator _validator;

        public UserRegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _validator = new UserValidator();
        }

        public void Register(UserRegistrationData data)
        {
            // 1. Валидация входных данных
            _validator.ValidateRegistration(data);

            // 2. Проверка уникальности email
            if (_userRepository.FindByEmail(data.Email) != null)
                throw new EmailAlreadyExistsException();

            // 3. Создание сущности
            var userEntity = new UserEntity
            {
                firstname = data.FirstName,
                lastname = data.LastName,
                password = data.Password,  
                email = data.Email
            };

            // 4. Сохранение в БД
            if (_userRepository.Create(userEntity) == 0)
                throw new RegistrationFailedException();
        }

        public class UserValidator
        {
            public void ValidateRegistration(UserRegistrationData data)
             {
                 if (data == null)
                     throw new ArgumentNullException(nameof(data));

                 if (string.IsNullOrWhiteSpace(data.FirstName))
                     throw new ValidationException();

                 if (string.IsNullOrWhiteSpace(data.LastName))
                     throw new ValidationException();

                 if (string.IsNullOrWhiteSpace(data.Email))
                     throw new ValidationException();

                 if (!IsValidEmail(data.Email))
                     throw new ValidationException();

                 if (string.IsNullOrWhiteSpace(data.Password))
                     throw new ValidationException();

                 if (data.Password.Length < 8)
                     throw new ValidationException();
             }         

            private bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }
        }

    }

}
