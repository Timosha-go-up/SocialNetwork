using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        private readonly AuthenticationView _authenticationView;
        private readonly RegistrationView _registrationView;

        public MainView(AuthenticationView authenticationView, RegistrationView registrationView)
        {
            _authenticationView = authenticationView;
            _registrationView = registrationView;
        }

        public void Show()
        {
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    _authenticationView.Show(); // Используем переданный экземпляр
                    break;
                case "2":
                    _registrationView.Show();   // Используем переданный экземпляр
                    break;
            }
        }
    }

}
