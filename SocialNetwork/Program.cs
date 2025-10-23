using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL;
using SocialNetwork.PLL.Views;
using System;
using System.Linq;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        public static FriendService friendServise;
        public static AddFriendView addFriendView;
        static UserService userService;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;

        static void Main(string[] args)
        {
            

            userService = new UserService();
            messageService = new MessageService();
            friendServise = new FriendService();
            addFriendView = new AddFriendView();
            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
                       
            var testUsers = new TestUsers();
            testUsers.CreateTestUsers();


            while (true)
            {
                mainView.Show();
            }
        }
    }
}
