using Microsoft.EntityFrameworkCore;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Infrastructure.DAL.Repositories;

public class PhoneBookRepository(SimpleCrudDbContext dbContext) : IPhoneBookRepository
{
    public IQueryable<PhoneBook> Query() =>
        dbContext.PhonesBooks
            .AsNoTracking();

    public async Task<IEnumerable<PhoneBook>> GetAllAsync() =>
        await dbContext.PhonesBooks
            .OrderBy(x => x.Name)
            .ToListAsync();

    public async Task<PhoneBook> GetAsyncById(Guid id) =>
        await dbContext.PhonesBooks.FirstOrDefaultAsync(pb => pb.Id == id);

    public async Task AddAsync(PhoneBook phoneBook)
    {
        await dbContext.AddAsync(phoneBook);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(PhoneBook phoneBook)
    {
        dbContext.Update(phoneBook);
        await dbContext.SaveChangesAsync();
    }

    public async Task Remove(PhoneBook phoneBook)
    {
        dbContext.PhonesBooks.Remove(phoneBook);
        await dbContext.SaveChangesAsync();
    }

    public async Task<PhoneBook> GetAsyncByPhoneNumber(string phoneNumber) =>
        await dbContext.PhonesBooks.FirstAsync(pb => pb.PhoneNumber == phoneNumber);
}