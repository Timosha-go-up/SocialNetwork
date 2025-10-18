namespace SocialNetwork.BLL.Exceptions
{
    [Serializable]
    internal class RegistrationFailedException : Exception
    {
        public RegistrationFailedException()
        {
        }

        public RegistrationFailedException(string? message) : base(message)
        {
        }

        public RegistrationFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}