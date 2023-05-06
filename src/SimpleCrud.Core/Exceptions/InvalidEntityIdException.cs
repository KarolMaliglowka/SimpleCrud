namespace SimpleCrud.Core.Exceptions;

public class InvalidEntityIdException : CustomException
{

    public InvalidEntityIdException() : base($"Id is invalid.")
    {
    }
}