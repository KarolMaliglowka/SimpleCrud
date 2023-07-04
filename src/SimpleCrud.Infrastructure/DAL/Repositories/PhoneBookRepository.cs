using Microsoft.EntityFrameworkCore;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Infrastructure.DAL.Repositories;

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

    public async Task Remove(Guid phoneBookId)
    {
        _dbContext.PhonesBooks.Remove(await GetAsyncById(phoneBookId));
         await _dbContext.SaveChangesAsync();
    }
}