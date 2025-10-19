using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services.UserServices.Common;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
namespace SocialNetwork.BLL.Services.UserServices
{
   

    public class UserProfileService(IUserRepository userRepository, IUserModelFactory modelFactory)        
      
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserModelFactory _modelFactory = modelFactory;

        public User FindByEmail(string email)
        {
            var userEntity = _userRepository.FindByEmail(email) ?? throw new UserNotFoundException();
            return _modelFactory.CreateFromEntity(userEntity);
        }

        public User FindById(int id)
        {
            var userEntity = _userRepository.FindById(id) ?? throw new UserNotFoundException();
            return _modelFactory.CreateFromEntity(userEntity);
        }

        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email,
                Photo = user.Photo,
                FavoriteMovie = user.FavoriteMovie,
                FavoriteBook = user.FavoriteBook
            };

            if (_userRepository.Update(updatableUserEntity) == 0)
                throw new UpdateFailedException();
        }
    }

}
