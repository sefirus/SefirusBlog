namespace Core.Exceptions;

public class BadRequestException : Exception
{
    public new string Message { get; set; }

    public BadRequestException()
    {
        Message = "Please, check your request";
    }

    public BadRequestException(string message) : base(message)
    {
        Message = message;
    }

    public BadRequestException(string message, Exception inner) : base(message, inner)
    {
        Message = message;
    }
}