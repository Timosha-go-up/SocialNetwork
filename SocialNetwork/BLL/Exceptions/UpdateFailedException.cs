namespace SocialNetwork.BLL.Exceptions
{
    [Serializable]
    internal class UpdateFailedException : Exception
    {
        public UpdateFailedException()
        {
        }

        public UpdateFailedException(string? message) : base(message)
        {
        }

        public UpdateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}