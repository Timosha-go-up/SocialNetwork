using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services.UserServices;
using SocialNetwork.PLL.MenuDesign;
using SocialNetwork.PLL.Views.AccountManagementView;
using SocialNetwork.PLL.Views.AccountManagementView.MessageViews;
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
                int incomingCount = user?.IncomingMessages?.Count() ?? 0;
                int outgoingCount = user?.OutgoingMessages?.Count() ?? 0;

                MenuData menuData = new(
                texts: 
                [
                "Входящие сообщения:",
                "Исходящие сообщения:",
                "Просмотреть информацию о моём профиле",
                "Редактировать мой профиль",
                "Добавить в друзья",
                "Написать сообщение",
                "Просмотреть входящие сообщения ",
                "Просмотреть исходящие сообщения ",
                "Выйти из профиля "
                ],

                suffixes:
                [
                 string.Empty,
                 string.Empty,
                 "(нажмите)",
                 "(нажмите)",
                 "(нажмите)",
                 "(нажмите)",
                 "(нажмите)",
                 "(нажмите)",
                 "(нажмите)",
                ],
                numbers: [incomingCount,outgoingCount,1,2,3,4,5,6,7]
                );


            var menuItems = MenuItem.CreateFromData(menuData);
            MenuFormat.Print(menuItems);
                                         
                string keyValue = ReadLine();

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
                        WriteLine("wrong input");
                        break;
                }
            }
        }
    }


    
}
