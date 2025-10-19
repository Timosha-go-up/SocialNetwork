using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services.UserServices.Common;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IFriendModelFactory _friendModelFactory;
        private readonly IUserRepository _userRepository;

        public FriendService(
            IFriendRepository friendRepository,
            IFriendModelFactory friendModelFactory,
            IUserRepository userRepository)
        {
            _friendRepository = friendRepository;
            _friendModelFactory = friendModelFactory;
            _userRepository = userRepository;
        }

        // Получить всех друзей пользователя
        public IEnumerable<Friend> GetFriends(int userId)
        {
            var entities = _friendRepository.FindAllByUserId(userId);
            return entities.Select(e => _friendModelFactory.CreateFromEntity(e));
        }

        // Добавить друга по email
        public void AddFriend(int userId, string friendEmail)
        {
            if (string.IsNullOrWhiteSpace(friendEmail))
                throw new ArgumentNullException(nameof(friendEmail));

            // Находим пользователя по email
            var friend = _userRepository.FindByEmail(friendEmail);
            if (friend == null)
                throw new UserNotFoundException();

            // Проверяем, не является ли это уже другом
            var existing = _friendRepository
                .FindAllByUserId(userId)
                .FirstOrDefault(f => f.friend_id == friend.Id);

            if (existing != null)
                throw new FriendAlreadyExistsException();

            // Создаём запись о дружбе
            var entity = new FriendEntity
            {
                user_id = userId,
                friend_id = friend.Id
            };

            _friendRepository.Create(entity);
        }

        // Удалить друга
        public void RemoveFriend(int friendRelationId)
        {
            _friendRepository.Delete(friendRelationId);
        }
    }

}
