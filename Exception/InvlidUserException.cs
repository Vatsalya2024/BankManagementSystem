using System.Diagnostics.CodeAnalysis;

namespace Simplifly.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class InvlidUserException : Exception
    {
        string message;
        public InvlidUserException()
        {
            message = "Invalid username or password";
        }

        public override string Message => message;
    }
}
