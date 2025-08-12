namespace SimpleCrud.Application.Dtos;

public record PhoneDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? PhoneNumber { get; init; }
};