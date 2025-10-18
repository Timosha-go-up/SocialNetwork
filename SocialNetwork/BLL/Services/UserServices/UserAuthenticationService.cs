using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services.UserServices.Common;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services.UserServices
{



    public class UserAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserModelFactory _modelFactory;

        public UserAuthenticationService(IUserRepository userRepository,UserModelFactory modelFactory)
                        
        {
            _userRepository = userRepository;
            _modelFactory = modelFactory;
        }

        public User Authenticate(UserAuthenticationData data)
        {
            var userEntity = _userRepository.FindByEmail(data.Email);
            if (userEntity == null)
                throw new UserNotFoundException();

            if (userEntity.password != data.Password) 
                throw new WrongPasswordException();

            return _modelFactory.CreateFromEntity(userEntity);
        }
    }



}
