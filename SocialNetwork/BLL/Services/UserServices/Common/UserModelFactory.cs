using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services.UserServices.Common
{
    public class UserModelFactory : IUserModelFactory
    {
        private readonly IMessageService _messageService;

        public UserModelFactory(IMessageService messageService)
        {
            _messageService = messageService ??
                throw new ArgumentNullException(nameof(messageService));
        }

        public User CreateFromEntity(UserEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var incomingMessages = _messageService.GetIncomingMessagesByUserId(entity.Id) ?? new List<Message>();
            var outgoingMessages = _messageService.GetOutgoingMessagesByUserId(entity.Id) ?? new List<Message>();

            return new User(
                entity.FirstName,
                entity.LastName,
                entity.Email,
                entity.Password,
                entity.Photo,
                entity.FavoriteMovie,
                entity.FavoriteBook,
                incomingMessages,
                outgoingMessages
            );
        }

    }



    public interface IUserModelFactory
    {
        User CreateFromEntity(UserEntity entity);
    }
    
    public class FriendModelFactory : IFriendModelFactory
    {
        private readonly IUserRepository _userRepository;

        public FriendModelFactory(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Friend CreateFromEntity(FriendEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            // Получаем email друга по friend_id
            var friendUser = _userRepository.FindById(entity.friend_id);
            var friendEmail = friendUser?.Email ?? "unknown@example.com";

            return new Friend(
                entity.id,
                entity.user_id,
                entity.friend_id,
                friendEmail
            );
        }
    }
    public interface IFriendModelFactory
    {
        Friend CreateFromEntity(FriendEntity entity);
    }


}
