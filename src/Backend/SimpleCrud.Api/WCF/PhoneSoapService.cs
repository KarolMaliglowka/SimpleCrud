using SimpleCrud.Application.Dtos;
using SimpleCrud.Application.Services;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Api.WCF;

public class PhoneSoapService : IPhoneSoapContract
{
    private readonly IPhoneBookRepository _phoneBookRepository;
    private readonly IPhoneService  _phoneService;

    public PhoneSoapService(IPhoneBookRepository phoneBookRepository, IPhoneService phoneService)
    {
        _phoneBookRepository = phoneBookRepository;
        _phoneService = phoneService;
    }

    public async Task<List<PhoneDto>>? GetPhones()
    {
        return await _phoneService.GetAllPhones();
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