using System;
using System.Runtime.Serialization;

namespace SocialNetwork.BLL.Exceptions
{
    [Serializable]
    internal class FriendAlreadyExistsException : Exception
    {
        public FriendAlreadyExistsException()
        {
        }

        public FriendAlreadyExistsException(string message) : base(message)
        {
        }

        public FriendAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FriendAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}