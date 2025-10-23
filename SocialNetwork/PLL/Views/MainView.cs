using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.MenuDesign;
using System;
using System.Collections.Generic;
using System.Text;
using static SocialNetwork.PLL.MenuDesign.MenuCollection;

namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            var menu = new MenuCollection();
           
            menu.Add(new MenuItem("Войти в профиль", number: 1));
            menu.Add(new MenuItem("Зарегистрироваться", number: 2));
            MenuFormat.Print(menu._items);
           

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.authenticationView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.registrationView.Show();
                        break;
                    }
            }
        }
    }
}
