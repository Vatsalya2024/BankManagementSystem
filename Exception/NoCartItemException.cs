using System.Runtime.Serialization;

namespace BOOKSTORE.Exception
{
    [Serializable]
    internal class NoCartItemException : System.Exception
    {
        private string message;
        public NoCartItemException()
        {
            message = "No cart Item found";
        }
        public override string Message => message;
    }
}