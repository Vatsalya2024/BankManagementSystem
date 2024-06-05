using System.Runtime.Serialization;

namespace BOOKSTORE.Exception
{
    [Serializable]
    internal class NoReviewException : System.Exception
    {
        private string message;
        public NoReviewException()
        {
            message = "No review found";
        }
        public override string Message => message;

    }
}