using System.Runtime.Serialization;

namespace BOOKSTORE.Exception
{
    [Serializable]
    internal class NoSuchOrderException : ApplicationException
    {
        private readonly string message;
        public NoSuchOrderException()
        {
            message = "No such order found";
        }

        public override string Message => message;
    }
}