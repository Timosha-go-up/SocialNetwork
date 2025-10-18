using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Services.UserServices;
using SocialNetwork.BLL.Services.UserServices.Common;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;
using System;
using static SocialNetwork.BLL.Services.UserServices.UserRegistrationService;

namespace SocialNetwork
{
    class Program
    {                                
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
            MessageService messageService  = new();
            UserModelFactory userModelFactory = new(messageService);
            UserRepository userRepository = new();
            UserRegistrationService userRegistrationService = new(userRepository);
            UserAuthenticationService userAuthenticationService =new(userRepository,userModelFactory);
            UserProfileService userProfileService = new(userRepository,userModelFactory);
            userMenuView = new UserMenuView(userProfileService);
            registrationView = new RegistrationView(userRegistrationService);
            authenticationView = new AuthenticationView(userAuthenticationService);
            mainView = new MainView();  
            userInfoView = new UserInfoView();
            
           

            while (true) { mainView.Show(); }
        }
    }
}