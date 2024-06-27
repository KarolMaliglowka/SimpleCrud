namespace SimpleCrud.Core.Entities;

public class PhoneBook(string phoneNumber, string name)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string PhoneNumber { get; set; } = phoneNumber;
    public string Name { get; set; } = name;
}