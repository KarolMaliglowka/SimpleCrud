﻿using SimpleCrud.Core.Entities;

namespace SimpleCrud.Core.Repositories;

public interface IPhoneBookRepository
{
    public IQueryable<PhoneBook> Query();
    Task<IEnumerable<PhoneBook>> GetAllAsync();
    Task<PhoneBook> GetAsyncById(Guid id);
    Task AddAsync(PhoneBook phoneBook);
    Task Update(PhoneBook phoneBook);
    Task Remove(PhoneBook phoneBook);
    Task<PhoneBook> GetAsyncByPhoneNumber(string phoneNumber);
}
