using SocialNetwork.PLL.MenuDesign;
using SocialNetwork.PLL.Views.AccountManagementView;
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
          MenuData menuData = new
          (
             texts: ["Войти в профиль", "Зарегистрироваться"],
             suffixes: ["(нажмите)", "(нажмите)"],
             numbers: [1, 2]
          );

          var menuItems = MenuItem.CreateFromData(menuData);
          MenuFormat.Print(menuItems);
                               
            switch (ReadLine())
            {
                case "1":
                    _authenticationView.Show(); 
                    break;
                case "2":
                    _registrationView.Show();   
                    break;

                default:
                    WriteLine("wrong input");
                    break;
            }
        }
      
        }
       
    }


