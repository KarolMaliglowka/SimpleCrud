using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Application.Attributes;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Infrastructure.DAL.Repositories;

[Injectable(ServiceLifetime.Scoped)]
public class PhoneBookRepository : IPhoneBookRepository
{
    private readonly SimpleCrudDbContext _dbContext;

    public PhoneBookRepository(SimpleCrudDbContext dbContext) => _dbContext = dbContext;

    public IQueryable<PhoneBook> Query() =>
        _dbContext.PhonesBooks
            .AsNoTracking();

    public async Task<IEnumerable<PhoneBook>> GetAllAsync() =>
        await _dbContext.PhonesBooks
            .OrderBy(x => x.Name)
            .ToListAsync();

    public async Task<PhoneBook> GetAsyncById(Guid id) =>
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
    
    public async Task<PhoneBook> GetAsyncByPhoneNumber(string phoneNumber) => 
        await _dbContext.PhonesBooks.FirstAsync(pb => pb.PhoneNumber == phoneNumber);
}