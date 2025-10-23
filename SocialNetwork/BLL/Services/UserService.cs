using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.PLL.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;

namespace SocialNetwork.BLL.Exceptions
{
    public class UserService
    {
        MessageService _messageService;
        IUserRepository _userRepository;
        private readonly TestUsers _testUsers;
        
        public UserService()
        {
            _userRepository = new UserRepository();
            _messageService = new MessageService();
        }
        
        public void Validation(UserRegistrationData userRegistrationData)
        {
            // Валидация через DataAnnotations
            var validationResult = new MyValidationResult();                      
            var validationContext = new ValidationContext(userRegistrationData);
            var dataAnnotationsErrors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(userRegistrationData,validationContext, dataAnnotationsErrors,true))                                                               
            {
                validationResult.AddErrors(dataAnnotationsErrors.Select(r => r.ErrorMessage));
            }
            
            if (_userRepository.FindByEmail(userRegistrationData.Email) != null)
            {
                validationResult.AddError($"Пользователь с email '{userRegistrationData.Email}' уже зарегистрирован");
            }

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public void Register(UserRegistrationData userRegistrationData)
        {               
            Validation(userRegistrationData);

            var userEntity = new UserEntity
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            if (_userRepository.Create(userEntity) == 0)
            throw new UserCreationFailedException(userRegistrationData);
        }


        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = _userRepository.FindByEmail(userAuthenticationData.Email)
                ?? throw new UserNotFoundException("Пользователь не найден");

            
            if (findUserEntity == null)
                throw new UserNotFoundException("Пользователь не найден");

            
            if (string.IsNullOrEmpty(findUserEntity.password) ||
                string.IsNullOrEmpty(userAuthenticationData.Password))
            {
                throw new ArgumentNullException("Пароль не может быть пустым");
            }
            
            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException("Неверный пароль");
          
            return ConstructUserModel(findUserEntity);
        }


        public User FindByEmail(string email)
        {
            var findUserEntity = _userRepository.FindByEmail(email);
            return findUserEntity is null 
            ? throw new UserNotFoundException() : ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = _userRepository.FindById(id);

            return findUserEntity is null ? throw new UserNotFoundException() : ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if (this._userRepository.Update(updatableUserEntity) == 0)
                throw new UserUpdateException();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = _messageService.GetIncomingMessagesByUserId(userEntity.id);

            var outgoingMessages = _messageService.GetOutcomingMessagesByUserId(userEntity.id);

            return new User(userEntity.id,
                          userEntity.firstname,
                          userEntity.lastname,
                          userEntity.password,
                          userEntity.email,
                          userEntity.photo,
                          userEntity.favorite_movie,
                          userEntity.favorite_book,
                          incomingMessages,
                          outgoingMessages
                          );
        }


       
    }

}
