namespace SimpleCrud.Core.Exceptions;

public class InvalidPhoneNumberException : CustomException
{
    public InvalidPhoneNumberException() : base("Phone number is invalid.")
    {
    }
}