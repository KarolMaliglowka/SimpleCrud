using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace SimpleCrud.Core.Entities;

public partial class PhoneBook
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

        if (phoneNumber.Length > 20)
        {
            throw new ArgumentException("Phone number cannot be more than 20 characters.", nameof(phoneNumber));
        }
        if (!MyRegex1().IsMatch(phoneNumber))
        {
            throw new ArgumentException("Invalid phone number format.", nameof(phoneNumber));
        }

        PhoneNumber = phoneNumber;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be empty.");
        }

        if (name.Length > 100)
        {
            throw new ArgumentException("Name cannot be more than 100 characters.", nameof(name));
        }

        if (!MyRegex().IsMatch(name))
        {
            throw new ArgumentException("Name can only contain letters and spaces.", nameof(name));
        }

        Name = name;
    }

    [GeneratedRegex(@"^[a-zA-Z\s]+$")]
    private static partial Regex MyRegex();
    [GeneratedRegex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")]
    private static partial Regex MyRegex1();
}