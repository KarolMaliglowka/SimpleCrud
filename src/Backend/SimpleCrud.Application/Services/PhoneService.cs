using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Entities;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Application.Services;

public interface IPhoneService
{
    Task<List<PhoneDto>> GetAllPhones();
    Task<PhoneDto?> GetById(Guid phoneId);
    Task<PhoneDto?> GetByName(string phoneName);
    Task<PhoneDto?> GetByNumber(string phoneNumber);
    Task<Guid> AddPhone(PhoneDto command);
    Task UpdatePhone(PhoneDto? command);
    Task DeletePhone(Guid phoneId);
    Task DeleteManyPhones(IEnumerable<Guid> phoneIds);
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

    public async Task<PhoneDto?> GetByName(string phoneName)
    {
        var phone = await _phoneBookRepository
            .GetAsyncByPhoneName(phoneName);
        return phone != null
            ? new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber,
                Description = phone.Description
            }
            : null;
    }

    public async Task<PhoneDto?> GetByNumber(string phoneNumber)
    {
        var phone = await _phoneBookRepository
            .GetAsyncByPhoneNumber(phoneNumber);
        return phone != null
            ? new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber,
                Description = phone.Description
            }
            : null;
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
            }
            : null;
    }

    public async Task<Guid> AddPhone(PhoneDto? command)
    {
        if (command == null) return Guid.NewGuid();
        var newPhone = new PhoneBook(command.PhoneNumber, command.Name, command.Description);
        await _phoneBookRepository.AddAsync(newPhone);
        return newPhone.Id;
    }

    public async Task UpdatePhone(PhoneDto? command)
    {
        var phone = await _phoneBookRepository.GetAsyncById(command.Id);
        if (phone == null)
        {
            throw new Exception("Phone not found");
        }

        phone.SetPhoneNumber(command.PhoneNumber);
        phone.SetName(command.Name);
        phone.SetDescription(command.Description);
        await _phoneBookRepository.Update(phone);
    }

    public async Task DeletePhone(Guid phoneId)
    {
        var phone = await _phoneBookRepository.GetAsyncById(phoneId);
        if (phone == null)
        {
            throw new Exception("No record in database :/");
        }

        await _phoneBookRepository.Remove(phone);
    }

    public async Task DeleteManyPhones(IEnumerable<Guid> phoneIds)
    {
        var phone = await _phoneBookRepository.GetAllAsync();
        var phonesToDelete = phone
            .Where(p =>
                phoneIds.Any(ids => ids == p.Id));
        var phoneBooks = phonesToDelete.ToList();
        if (phoneBooks.Count == 0)
        {
            throw new Exception("No records in database :/");
        }

        await _phoneBookRepository.RemoveMany(phoneBooks);
    }
}