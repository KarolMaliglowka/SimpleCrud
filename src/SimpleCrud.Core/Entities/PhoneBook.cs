using SimpleCrud.Core.ValueObjects;

namespace SimpleCrud.Core.Entities;

public class PhoneBook
{
    public Id Id { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Name Name { get; set; }

    public PhoneBook(PhoneNumber phoneNumber, Name name)
    {
        Id = Guid.NewGuid();
        SetPhoneNumber(phoneNumber);
        SetName(name);
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetPhoneNumber(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
}