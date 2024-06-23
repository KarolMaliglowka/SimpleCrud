using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Application.Abstractions.Queries;
using SimpleCrud.Application.Attributes;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Application.Queries;

public class GetPositionByNumber : IQuery<PhoneDto>
{
    public string PhoneNumebr { get; set; }
}

[Injectable(ServiceLifetime.Scoped)]
public class GetPositionByNumberHandler : IQueryHandler<GetPositionByNumber, PhoneDto>
{
    private readonly IPhoneBookRepository _phoneBookRepository;

    public GetPositionByNumberHandler(IPhoneBookRepository phoneBookRepository)
    {
        _phoneBookRepository = phoneBookRepository;
    }

    public async Task<PhoneDto> HandleAsync(GetPositionByNumber query)
    {
        var result = await _phoneBookRepository.GetAsyncByPhoneNumber(query.PhoneNumebr);
        
        if (result is null)
        {
            throw new NullReferenceException();
        }
        
        return new PhoneDto(
            result.Id,
            result.Name,
            result.PhoneNumber);
    }
}