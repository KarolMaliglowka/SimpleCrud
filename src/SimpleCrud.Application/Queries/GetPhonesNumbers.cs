using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Application.Abstractions.Queries;
using SimpleCrud.Application.Attributes;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Application.Queries;

public class GetPhonesNumbers : IQuery<List<PhoneDto>>
{
}

public class GetPhonesNumbersHandler : IQueryHandler<GetPhonesNumbers, List<PhoneDto>>
{
    private readonly IPhoneBookRepository _phoneBookRepository;

    public GetPhonesNumbersHandler(IPhoneBookRepository phoneBookRepository) =>
        _phoneBookRepository = phoneBookRepository;

    public Task<List<PhoneDto>> HandleAsync(GetPhonesNumbers query)
    {
        return Task.FromResult<List<PhoneDto>>
        (
            _phoneBookRepository.Query()
                .Select
                (
                    x => new PhoneDto(
                        x.Id,
                        x.Name,
                        x.PhoneNumber
                    )
                )
                .ToList()
        );
    }
}