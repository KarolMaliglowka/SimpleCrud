using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Api;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("", async (IPhoneBookRepository phoneBookRepository) =>
        {
            var getAllAsync = (await phoneBookRepository.GetAllAsync())
                .ToList();
            return getAllAsync.ToList();
        });
        
        
        app.MapGet("getById/{phoneId:guid}", async (IPhoneBookRepository phoneBookRepository, Guid phoneId) =>
        {
            var phone = await phoneBookRepository
                .GetAsyncById(phoneId);
            if (phone == null)
            {
                throw new NullReferenceException("No record in database :/");
            }

            return new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber
            };
        });
        
    }
}