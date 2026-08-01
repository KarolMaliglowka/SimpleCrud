using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Api.WCF;

public class PhoneSoapService : IPhoneSoapContract
{
    private readonly IPhoneBookRepository _phoneBookRepository;

    public PhoneSoapService(IPhoneBookRepository phoneBookRepository)
    {
        _phoneBookRepository = phoneBookRepository;
    }

    public async Task<List<PhoneDto>>? GetPhones()
    {
        //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
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
        //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
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

    public async Task<PhoneDto?> GetByName(string phoneName)
    {
        //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
        var phone = await _phoneBookRepository.GetAsyncByPhoneName(phoneName);
        return phone != null
            ? new PhoneDto
            {
                Id = phone.Id,
                Name = phone.Name,
                PhoneNumber = phone.PhoneNumber,
                Description = phone.Description
            } : null;
    }

    public async Task<PhoneDto?> GetByNumber(string phoneNumber)
    {
        //przenieść do Services w Application i zmienić na wspólny kod REST i SOAP
        var phone = await _phoneBookRepository.GetAsyncByPhoneNumber(phoneNumber);
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
}