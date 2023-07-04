using SimpleCrud.Core.Entities;

namespace SimpleCrud.Core.Repositories;

public interface IPhoneBookRepository
{
    public IQueryable<PhoneBook> Query();
    Task<IEnumerable<PhoneBook>> GetAllAsync();
    Task<PhoneBook> GetAsyncById(Guid id);
    Task AddAsync(PhoneBook phoneBook);
    Task UpdateAsync(PhoneBook phoneBook);
    Task Remove(Guid phoneBookId);
}
