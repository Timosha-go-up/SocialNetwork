using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var deps = new AppDependencies();

            var testUsers = new List<User>
            {
             new User("Иван", "Иванов", "ivan@example.com","12345678"),
             new User("Мария", "Петрова", "maria@example.com", "543211234"),
             new User("Алексей", "Сидоров", "alex@example.com", "qwerty123"),
             new User("Елена", "Васильева", "elena@example.com", "password12"),
             new User("Дмитрий", "Николаев", "dmitry@example.com", "test123321")
             };

            foreach (var user in testUsers)
            {
                deps.UserRepository.Add(user);
               
            }

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
                deps.UserAuthenticationService,
                userMenuView
            );

            var mainView = new MainView(authenticationView, registrationView);


            while (true)
            {
                mainView.Show();
            }
        }
    }
}
