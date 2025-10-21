using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services.UserServices;
using SocialNetwork.BLL.Services.UserServices.Common;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Repositories.SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.TestUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{

    public class ServiceContainer
    {
        public IUserRepository UserRepository { get; }
        public IMessageService MessageService { get; }
        public IUserModelFactory UserModelFactory { get; }
        public IFriendModelFactory FriendModelFactory { get; }
        public UserRegistrationService UserRegistrationService { get; }
        public UserAuthenticationService UserAuthenticationService { get; }
        public UserProfileService UserProfileService { get; }
        public FriendService FriendService { get; }
        public TestDataInitializer TestDataInitializer { get; }
        public ServiceContainer(bool initializeTestData = false)
        {
            // 1. Базовые репозитории и сервисы
            UserRepository = new UserRepository();
            MessageService = new MessageService();
            TestDataInitializer = new TestDataInitializer(UserRepository);
            // 2. Фабрики
            UserModelFactory = new UserModelFactory(MessageService);
            FriendModelFactory = new FriendModelFactory(UserRepository);

            // 3. Сервисы
            UserRegistrationService = new UserRegistrationService(UserRepository);
            UserAuthenticationService = new UserAuthenticationService(UserRepository, UserModelFactory);
            UserProfileService = new UserProfileService(UserRepository, UserModelFactory);
            FriendService = new FriendService(new FriendRepository(),  FriendModelFactory,UserRepository  );

            if (initializeTestData)
            {
                TestDataInitializer.InitializeTestUsers();
            }
        }
      
    }


   


}
