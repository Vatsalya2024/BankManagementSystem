using System.Runtime.Serialization;

namespace BOOKSTORE.Exception
{
    [Serializable]
    internal class NoUserException : ApplicationException
    {
        public NoUserException()
        {
        }

        public NoUserException(string? message) : base(message)
        {
        }


    }
}