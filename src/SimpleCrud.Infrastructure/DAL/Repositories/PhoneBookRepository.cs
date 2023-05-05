using Microsoft.EntityFrameworkCore;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;
using SimpleCrud.Core.ValueObjects;

namespace SimpleCrud.Infrastructure.DAL.Repositories;

public class PhoneBookRepository : IPhoneBookRepository
{
    private readonly SimpleCrudDbContext _dbContext;

    public PhoneBookRepository(SimpleCrudDbContext dbContext) => _dbContext = dbContext;

    public IQueryable<PhoneBook> Query() => _dbContext.PhonesBooks.AsNoTracking();

    public async Task<PhoneBook> GetAsyncById(Id id) =>
        await _dbContext.PhonesBooks.FirstAsync(pb => pb.Id == id);

    public async Task AddAsync(PhoneBook phoneBook)
    {
        await _dbContext.AddAsync(phoneBook);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PhoneBook phoneBook)
    {
        _dbContext.Update(phoneBook);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Remove(PhoneBook phoneBook)
    {
        _dbContext.PhonesBooks.Remove(phoneBook);
        await _dbContext.SaveChangesAsync();
    }
}