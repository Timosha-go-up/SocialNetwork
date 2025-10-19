
namespace SocialNetwork.BLL.Services
{
    [Serializable]
    internal class FriendAlreadyExistsException : Exception
    {
        public FriendAlreadyExistsException()
        {
        }

        public FriendAlreadyExistsException(string? message) : base(message)
        {
        }

        public FriendAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}