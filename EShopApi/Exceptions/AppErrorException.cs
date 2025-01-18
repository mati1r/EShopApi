namespace ApiTemplate.Exceptions;

public class AppErrorException : Exception
{
    public AppErrorException()
    { }

    public AppErrorException(string message) : base(message)
    { }

    public AppErrorException(string message, Exception inner) : base(message, inner)
    { }
}

