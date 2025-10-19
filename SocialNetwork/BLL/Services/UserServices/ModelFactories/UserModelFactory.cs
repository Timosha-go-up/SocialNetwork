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
            _messageService = messageService;
        }

        public User CreateFromEntity(UserEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var incomingMessages = _messageService.GetIncomingMessagesByUserId(entity.id);
            var outgoingMessages = _messageService.GetOutcomingMessagesByUserId(entity.id);

            return new User(
                entity.id,
                entity.firstname,
                entity.lastname,
                entity.password,
                entity.email,
                entity.photo,
                entity.favorite_movie,
                entity.favorite_book,
                incomingMessages,
                outgoingMessages
            );
        }
    }


    public interface IUserModelFactory
    {
        User CreateFromEntity(UserEntity entity);
    }
    
   


}
