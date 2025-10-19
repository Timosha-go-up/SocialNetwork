using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var deps = new AppDependencies();


            

            // Представления пользователя
            var userInfoView = new UserInfoView();
            var userDataUpdateView = new UserDataUpdateView(deps.UserProfileService);

            // Сообщения
            var messageSendingView = new MessageSendingView(deps.MessageService, deps.UserProfileService);
            var userIncomingMessageView = new UserIncomingMessageView();
            var userOutcomingMessageView = new UserOutcomingMessageView();

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
