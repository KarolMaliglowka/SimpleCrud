using CoreWCF;
using SimpleCrud.Application.Dtos;

namespace SimpleCrud.Api.SOAP;

[ServiceContract]
public interface IPhoneSoapContract
{
    [OperationContract]
    Task<List<PhoneDto>>? GetPhones();
    [OperationContract]
    Task<PhoneDto?> GetById(Guid phoneId);
    [OperationContract]
    Task<PhoneDto?> GetByName(string phoneName);
    [OperationContract]
    Task<PhoneDto?> GetByNumber(string phoneNumber);
}