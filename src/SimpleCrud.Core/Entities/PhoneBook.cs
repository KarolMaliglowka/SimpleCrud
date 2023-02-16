namespace SimpleCrud.Core.Entities;

public class PhoneBook
{
    public Guid Id { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public PhoneBook(string phoneNumber, string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        SetPhoneNumber(phoneNumber);
        SetFirstName(firstName);
        SetLastName(lastName);
    }

    public void SetFirstName(string firstName)
    {
        _ = firstName ?? throw new ArgumentException("First name cannot be null", nameof(firstName));

        if (firstName.Length < 2)
        {
            throw new ArgumentException("First name cannot be short than 2 chars", nameof(firstName));
        }

        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        LastName = lastName;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        _ = phoneNumber ?? throw new ArgumentException("Phone number cannot be null", nameof(phoneNumber));

        if (phoneNumber.Length < 2)
        {
            throw new ArgumentException("First name cannot be short than 2 chars", nameof(phoneNumber));
        }

        PhoneNumber = phoneNumber;
    }
}