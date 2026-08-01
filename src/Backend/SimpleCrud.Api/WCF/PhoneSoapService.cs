using SimpleCrud.Application.Dtos;
using SimpleCrud.Application.Services;

namespace SimpleCrud.Api.WCF;

public class PhoneSoapService(IPhoneService phoneService) : IPhoneSoapContract
{
    public async Task<List<PhoneDto>> GetPhones() =>
        await phoneService.GetAllPhones();

    public async Task<PhoneDto> GetById(Guid phoneId) =>
        await phoneService.GetById(phoneId);

    public async Task<PhoneDto> GetByName(string phoneName) =>
        await phoneService.GetByName(phoneName);

    public async Task<PhoneDto> GetByNumber(string phoneNumber) =>
        await phoneService.GetByNumber(phoneNumber);

    public async Task<Guid> AddPhone(PhoneDto command) =>
        await phoneService.AddPhone(command);

    public async Task UpdatePhone(PhoneDto command) =>
        await phoneService.UpdatePhone(command);

    public async Task DeletePhone(Guid phoneId) =>
        await phoneService.DeletePhone(phoneId);

    public async Task DeleteManyPhones(List<Guid> phoneIds) =>
        await phoneService.DeleteManyPhones(phoneIds);
}