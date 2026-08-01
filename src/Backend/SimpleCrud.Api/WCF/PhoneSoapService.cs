using SimpleCrud.Application.Dtos;
using SimpleCrud.Application.Services;

namespace SimpleCrud.Api.WCF;

public class PhoneSoapService(IPhoneService phoneService) : IPhoneSoapContract
{
    public async Task<List<PhoneDto>>? GetPhones()
    {
        return await phoneService.GetAllPhones();
    }

    public async Task<PhoneDto?> GetById(Guid phoneId)
    {
        return await phoneService.GetById(phoneId);
    }

    public async Task<PhoneDto?> GetByName(string phoneName)
    {
        return await phoneService.GetByName(phoneName);
    }

    public async Task<PhoneDto?> GetByNumber(string phoneNumber)
    {
        return await phoneService.GetByNumber(phoneNumber);
    }
    
    public async Task<Guid> AddPhone(PhoneDto command)
    {
        return await phoneService.AddPhone(command);
    }
    
    public async Task UpdatePhone(PhoneDto? command)
    {
        await phoneService.UpdatePhone(command);
    }
    
    public async Task DeletePhone(Guid phoneId)
    {
        await phoneService.DeletePhone(phoneId);
    }
    
    public async Task DeleteManyPhones(List<Guid> phoneIds)
    {
        await phoneService.DeleteManyPhones(phoneIds);
    }
}