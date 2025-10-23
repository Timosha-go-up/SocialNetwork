using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.MenuDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SocialNetwork.PLL.MenuDesign.MenuCollection;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        UserService userService;
        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            while(true)
            {
                int incomingCount = user?.IncomingMessages?.Count() ?? 0;
                int outgoingCount = user?.OutgoingMessages?.Count() ?? 0;

                var menu = new MenuCollection();
                menu.Add(new MenuItem("Входящие сообщения:",string.Empty, number: incomingCount));
                menu.Add(new MenuItem("Исходящие сообщения:",string.Empty, number: outgoingCount));
                menu.Add(new MenuItem("Просмотреть информацию о моём профиле", string.Empty, number: 1));
                menu.Add(new MenuItem("Редактировать мой профиль", string.Empty, number: 2));
                menu.Add(new MenuItem("Добавить в друзья", string.Empty, number: 3));
                menu.Add(new MenuItem("Написать сообщение", string.Empty, number: 4));
                menu.Add(new MenuItem("Просмотреть входящие сообщения ", string.Empty, number: 5));
                menu.Add(new MenuItem("Просмотреть исходящие сообщения ", string.Empty, number: 6));
                menu.Add(new MenuItem("Выйти из профиля ", string.Empty, number: 7));
                MenuFormat.Print(menu._items);
               
                string keyValue = Console.ReadLine();

                if (keyValue == "7") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.userDataUpdateView.Show(user);
                            break;
                        } 
                    case "3":
                        Program.addFriendView.Show(user);
                        break;

                    case "4":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }

                    case "5":
                        {

                            Program.userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }

                    case "6":
                        {
                            Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }
                }
            }
            
        }
    }
}
