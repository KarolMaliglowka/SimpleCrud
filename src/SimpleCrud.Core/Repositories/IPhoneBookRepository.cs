using SimpleCrud.Core.Entities;
using SimpleCrud.Core.ValueObjects;

namespace SimpleCrud.Core.Repositories;

public interface IPhoneBookRepository
{
    public IQueryable<PhoneBook> Query();
    Task<PhoneBook> GetAsyncById(Guid id);
    Task AddAsync(PhoneBook weeklyParkingSpot);
    Task UpdateAsync(PhoneBook weeklyParkingSpot);

    Task Remove(PhoneBook weeklyParkingSpot);
}