using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;
using System;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {   UserRepository _userRepository;
        FriendRepository _friendRepository;

        public FriendService()
        {
             _userRepository = new UserRepository();
            _friendRepository = new FriendRepository();

        }

        public void AddFriend(int userId, string friendEmail)
        {
            if (string.IsNullOrWhiteSpace(friendEmail))
                throw new ArgumentNullException(nameof(friendEmail));

            // Находим пользователя по email
            var friend = _userRepository.FindByEmail(friendEmail) ?? throw new UserNotFoundException();

            // Проверяем, не является ли это уже другом
            var existing = _friendRepository
                .FindAllByUserId(userId)
                .FirstOrDefault(f => f.friend_id == friend.id);

            if (existing != null)
                throw new FriendAlreadyExistsException();

            // Создаём запись о дружбе
            var entity = new FriendEntity
            {
                user_id = userId,
                friend_id = friend.id
            };

            _friendRepository.Create(entity);
        }
    }
}