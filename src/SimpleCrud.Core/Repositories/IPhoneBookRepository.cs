using SimpleCrud.Core.Entities;
using SimpleCrud.Core.ValueObjects;

namespace SimpleCrud.Core.Repositories;

public interface IPhoneBookRepository
{
    public IQueryable<PhoneBook> Query();
    Task<PhoneBook> GetAsyncById(Id id);
    Task AddAsync(PhoneBook phoneBook);
    Task UpdateAsync(PhoneBook phoneBook);
    Task Remove(PhoneBook phoneBook);
}
