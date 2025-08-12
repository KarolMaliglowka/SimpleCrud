namespace SimpleCrud.Core.Exceptions;

public class InvalidNameException : CustomException
{
    public InvalidNameException() : base("Name is invalid.")
    {
    }
}