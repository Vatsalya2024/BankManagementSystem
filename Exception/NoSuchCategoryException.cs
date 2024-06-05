using System.Runtime.Serialization;

namespace BOOKSTORE.Exception
{
    [Serializable]
    internal class NoSuchCategoryException : ApplicationException
    {
        private string message;
        public NoSuchCategoryException()
        {
            message = "No such category found";
        }

        public override string Message => message;

    }
}