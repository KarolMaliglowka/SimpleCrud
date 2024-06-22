using SimpleCrud.Application.Abstractions.Queries;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Application.Queries;

public class GetPhonesNumbers : IQuery<IEnumerable<PhoneDto>>
{
}

public class GetPhonesNumbersHandler : IQueryHandler<GetPhonesNumbers, IEnumerable<PhoneDto>>
{
    private readonly IPhoneBookRepository _phoneBookRepository;

    public GetPhonesNumbersHandler(IPhoneBookRepository phoneBookRepository) =>
        _phoneBookRepository = phoneBookRepository;

    public Task<IEnumerable<PhoneDto>> HandleAsync(GetPhonesNumbers query)
    {
        return Task.FromResult<IEnumerable<PhoneDto>>
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