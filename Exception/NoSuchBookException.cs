namespace BOOKSTORE.Exception
{
    public class NoSuchBookException:ApplicationException
    {
        private string message;
        public NoSuchBookException()
        {
            message = "No book found";
        }
        public override string Message => message;
    }
}
