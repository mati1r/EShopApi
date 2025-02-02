namespace Core.Exceptions;

public class AuthorizationErrorException : Exception
{
    public AuthorizationErrorException() 
    { }
    public AuthorizationErrorException(string message) : base(message)
    { }
    public AuthorizationErrorException(string message, Exception inner) : base(message, inner)
    { }
}
