namespace SimpleCrud.Core.Exceptions;

public class InvalidPhoneNumberException : CustomException
{
    private string Value { get; }

    public InvalidPhoneNumberException(string value) : base($"Phone number: '{value}' is invalid.")
    {
        Value = value;
    }
}