namespace SimpleCrud.Application.Dtos;

public record PhoneDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
};