using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;
using SocialNetwork.PLL.Views.AccountManagementView;
using SocialNetwork.PLL.Views.AccountManagementView.MessageViews;
namespace SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {    
            // инициализация тестовых пользователей
            var deps = new ServiceContainer(initializeTestData: true);
           
            // Представления пользователя
            var userInfoView = new UserInfoView();
            var userDataUpdateView = new UserDataUpdateView(deps.UserProfileService);

            // Сообщения
            var messageSendingView = new MessageSendingView(deps.MessageService, deps.UserProfileService);
            var userIncomingMessageView = new UserIncomingMessageView();
            var userOutcomingMessageView = new UserOutgoingMessageView();

            // Другие представления
            var registrationView = new RegistrationView(deps.UserRegistrationService);
            var addFriendView = new AddFriendView(deps.FriendService, deps.UserProfileService);

            // Составные представления
            var userMenuView = new UserMenuView(
                deps.UserProfileService,
                userInfoView,
                userDataUpdateView,
                addFriendView,
                messageSendingView,
                userIncomingMessageView,
                userOutcomingMessageView
            );

            var authenticationView = new AuthenticationView(
                deps.UserAuthenticationService,userMenuView
                
            );

            var mainView = new MainView(authenticationView,registrationView);


            while (true)
            {
                mainView.Show();
            }
        }
    }
}
