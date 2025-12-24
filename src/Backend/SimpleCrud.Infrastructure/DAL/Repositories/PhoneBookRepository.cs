using Microsoft.EntityFrameworkCore;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Infrastructure.DAL.Repositories;

public class PhoneBookRepository(SimpleCrudDbContext dbContext) : IPhoneBookRepository
{
    public async Task<List<PhoneBook>> GetAllAsync() =>
        await dbContext.PhonesBooks
            .OrderBy(x => x.Name)
            .ToListAsync();

    public async Task<PhoneBook> GetAsyncById(Guid id) =>
        await dbContext.PhonesBooks.FirstOrDefaultAsync(pb => pb.Id == id);

    public async Task AddAsync(PhoneBook phoneBook)
    {
        dbContext.Add(phoneBook);
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
    
    public async Task RemoveMany(IEnumerable<PhoneBook> phoneBooks)
    {
        dbContext.PhonesBooks.RemoveRange(phoneBooks);
        await dbContext.SaveChangesAsync();
    }

    public async Task<PhoneBook> GetAsyncByPhoneNumber(string phoneNumber) =>
        await dbContext.PhonesBooks.FirstAsync(pb => pb.PhoneNumber == phoneNumber);
    
    public async Task<PhoneBook> GetAsyncByPhoneName(string phoneName) =>
        await dbContext.PhonesBooks.FirstAsync(pb => pb.Name == phoneName);

    public Task<bool> ExistByPhoneNumber(string phoneNumber) =>
         dbContext.PhonesBooks.AnyAsync(pb => pb.PhoneNumber == phoneNumber);
    
    public Task<bool> ExistByPhoneName(string phoneName) =>
        dbContext.PhonesBooks.AnyAsync(pb => pb.Name == phoneName);
}