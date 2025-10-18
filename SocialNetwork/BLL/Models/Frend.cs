using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; }
        public int UserId { get; }
        public int FriendId { get; }
        public string FriendEmail { get; }  // Удобно для отображения

        public Friend(int id, int userId, int friendId, string friendEmail)
        {
            Id = id;
            UserId = userId;
            FriendId = friendId;
            FriendEmail = friendEmail;
        }
    }

}
