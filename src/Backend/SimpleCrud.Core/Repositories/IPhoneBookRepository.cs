using SimpleCrud.Core.Entities;

namespace SimpleCrud.Core.Repositories;

public interface IPhoneBookRepository
{
    Task<List<PhoneBook>> GetAllAsync();
    Task<PhoneBook> GetAsyncById(Guid id);
    Task AddAsync(PhoneBook phoneBook);
    Task Update(PhoneBook phoneBook);
    Task Remove(PhoneBook phoneBook);
    Task RemoveMany(IEnumerable<PhoneBook> phoneBooks);
    Task<PhoneBook> GetAsyncByPhoneNumber(string phoneNumber);
    Task<PhoneBook> GetAsyncByPhoneName(string phoneName);
    Task<bool> ExistByPhoneName(string phoneName);
    Task<bool> ExistByPhoneNumber(string phoneName);
}
