using System.Diagnostics.CodeAnalysis;

namespace SimpleCrud.Core.Entities;

public class PhoneBook
{
    [ExcludeFromCodeCoverage]
    public PhoneBook()
    {
    }

    public PhoneBook(string phoneNumber, string name)
    {
        SetPhoneNumber(phoneNumber);
        SetName(name);
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string PhoneNumber { get; set; }
    public string Name { get; set; }

    private void SetPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentNullException(nameof(phoneNumber), "Phone number cannot be empty.");
        }

        PhoneNumber = phoneNumber;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be empty.");
        }

        Name = name;
    }
}