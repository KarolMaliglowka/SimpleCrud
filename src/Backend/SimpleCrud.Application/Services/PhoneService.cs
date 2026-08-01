using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Application.Services;

public interface IPhoneService
{
    Task<List<PhoneDto>> GetAllPhones();
    Task<PhoneDto?> GetById(Guid phoneId);
}

public class PhoneService : IPhoneService
{
    private readonly IPhoneBookRepository _phoneBookRepository;

    public PhoneService(IPhoneBookRepository phoneBookRepository)
    {
        _phoneBookRepository = phoneBookRepository;
    }
    
    public async Task<List<PhoneDto>> GetAllPhones()
    {
        var getAllAsync = await _phoneBookRepository.GetAllAsync();
        return
        [
            .. getAllAsync.Select(phone => new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber,
                Description = phone.Description
            })
        ];
    }

    public async Task<PhoneDto?> GetById(Guid phoneId)
    {
        var phone = await _phoneBookRepository
            .GetAsyncById(phoneId);
        return phone != null
            ? new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber,
                Description = phone.Description
            } : null;
    }
    
}