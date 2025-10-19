using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Services.UserServices;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views.AccountManagementView
{
    public class AuthenticationView
    {
        private readonly UserAuthenticationService _userAuthenticationService;
        private readonly UserMenuView _userMenuView;

        public AuthenticationView(
            UserAuthenticationService userAuthenticationService,
            UserMenuView userMenuView)
        {
            _userAuthenticationService = userAuthenticationService;
            _userMenuView = userMenuView;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = _userAuthenticationService.Authenticate(authenticationData);

                SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожаловать " + user.FirstName);

                _userMenuView.Show(user); // Вызываем метод у переданного экземпляра
            }
            catch (WrongPasswordException)
            {
                AlertMessage.Show("Пароль не корректный!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
        }
    }


}
