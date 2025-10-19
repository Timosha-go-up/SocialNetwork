using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Services.UserServices;
using SocialNetwork.PLL.Views.AccountManagementView;
using SocialNetwork.PLL.Views.AccountManagementView.MessageViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        private readonly UserProfileService _profileService;
        private readonly UserInfoView _userInfoView;
        private readonly UserDataUpdateView _userDataUpdateView;
        private readonly AddFriendView _addFriendView;
        private readonly MessageSendingView _messageSendingView;
        private readonly UserIncomingMessageView _userIncomingMessageView;
        private readonly UserOutgoingMessageView _userOutcomingMessageView;

        public UserMenuView(
            UserProfileService profileService,
            UserInfoView userInfoView,
            UserDataUpdateView userDataUpdateView,
            AddFriendView addFriendView,
            MessageSendingView messageSendingView,
            UserIncomingMessageView userIncomingMessageView,
            UserOutgoingMessageView userOutcomingMessageView)
        {
            _profileService = profileService;
            _userInfoView = userInfoView;
            _userDataUpdateView = userDataUpdateView;
            _addFriendView = addFriendView;
            _messageSendingView = messageSendingView;
            _userIncomingMessageView = userIncomingMessageView;
            _userOutcomingMessageView = userOutcomingMessageView;

        }

        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
                Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());

                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Просмотреть входящие сообщения (нажмите 5)");
                Console.WriteLine("Просмотреть исходящие сообщения (нажмите 6)");
                Console.WriteLine("Выйти из профиля (нажмите 7)");

                string keyValue = Console.ReadLine();

                if (keyValue == "7") break;

                switch (keyValue)
                {
                    case "1":
                        _userInfoView.Show(user);
                        break;
                    case "2":
                        _userDataUpdateView.Show(user);
                        break;
                    case "3":
                        _addFriendView.Show(user);
                        break;
                    case "4":
                        _messageSendingView.Show(user);
                        break;
                    case "5":
                        _userIncomingMessageView.Show(user.IncomingMessages);
                        break;
                    case "6":
                        _userOutcomingMessageView.Show(user.OutgoingMessages);
                        break;

                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
            }
        }
    }


}
