using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;
        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

           
            Console.Write("Cоздания нового профиля\nВаше имя: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Почтовый адрес: ");
            userRegistrationData.Email = Console.ReadLine();

            Console.Write("Пароль: ");
            userRegistrationData.Password = Console.ReadLine();
            Console.WriteLine();
            try
            {
                this.userService.Register(userRegistrationData);
                SuccessMessage.Show("Ваш профиль успешно создан.\nТеперь Вы можете войти в систему под своими учетными данными.");
            }
            catch (BLL.Exceptions.ValidationException ex)
            {                
                string formattedErrors = ValidationExceptions.GetFormattedErrors(ex);

                AlertMessage.Show($"Ошибки:\n{formattedErrors}");
            }
            catch (UserCreationFailedException)
            {
                AlertMessage.Show("Не удалось сохранить данные в базу");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Неожиданная ошибка: {ex}");
                AlertMessage.Show("Произошла непредвиденная ошибка.");
            }
        }

    }
}
