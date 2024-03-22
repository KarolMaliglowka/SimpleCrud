namespace SimpleCrud.Core.Entities;

public class PhoneBook
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Name { get; set; }

    public PhoneBook(string phoneNumber, string name)
    {
        Id = Guid.NewGuid();
        PhoneNumber = phoneNumber;
        Name = name;
    }
}