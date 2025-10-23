using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    public class Frend
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int friend_id { get; set; }

        public Frend(int Id,int UserId,int FriendId)
        {
            int id = Id;
            user_id = UserId;
            friend_id = FriendId;
        }
    }
}
