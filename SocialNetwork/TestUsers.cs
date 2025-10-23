using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork
{
    

    public class TestUsers
    {public string[] FirstName { get; set; }
        public string[] LastName { get; set; }
        public string[] Password { get; set; }
        public string[] Email { get; set; }
        public bool[] success { get; set; }
        // Массивы для хранения данных
        private string[] _firstNames;
        private string[] _lastNames;
        private string[] _emails;
        private string[] _passwords;
        private bool[] _successes;

        private UserService _userService;

        // Конструктор с инициализацией 5 тестовых пользователей
        public TestUsers()
        {
            // Инициализация массивов для 5 пользователей
            _firstNames = new string[] {
            "Иван",
            "Петр",
            "Анна",
            "Мария",
            "Сергей"
        };

            _lastNames = [
            "Иванов",
            "Петров",
            "Сидорова",
            "Иванова",
            "Михайлов"
        ];

            _emails = new string[] {
            "ivan@example.com",
            "petr@example.com",
            "anna@example.com",
            "maria@example.com",
            "sergey@example.com"
        };

            _passwords = new string[] {
            "password123",
            "password456",
            "password789",
            "password012",
            "password345"
        };

            _successes = new bool[5];

            // Создание экземпляра UserService
            _userService = new UserService();
        }

        // Метод для создания тестовых пользователей
        public void CreateTestUsers()
        {
            ValidateInput();
            ProcessUserCreation();
            DisplaySuccessfulRegistrations();
        }

        private void ValidateInput()
        {
            if (_firstNames.Length != _lastNames.Length ||
                _firstNames.Length != _emails.Length ||
                _firstNames.Length != _passwords.Length)
            {
                throw new ArgumentException("Массивы пользователей должны быть одинаковой длины");
            }
        }

        private void ProcessUserCreation()
        {
            for (int i = 0; i < _firstNames.Length; i++)
            {
                try
                {
                    var userRegistrationData = new UserRegistrationData
                    {
                        FirstName = _firstNames[i],
                        LastName = _lastNames[i],
                        Email = _emails[i],
                        Password = _passwords[i]
                    };

                    _userService.Register(userRegistrationData);
                    _successes[i] = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при создании тестового пользователя: {ex.Message}");
                    _successes[i] = false;
                }
            }
        }

        private void DisplaySuccessfulRegistrations()
        {
            for (int i = 0; i < _firstNames.Length; i++)
            {
                if (_successes[i])
                {
                    SuccessMessage.Show($"Успешно зарегистрирован: {_firstNames[i]} {_lastNames[i]} ({_emails[i]}) ({_passwords[i]})");
                }
            }
        }
    }



}
