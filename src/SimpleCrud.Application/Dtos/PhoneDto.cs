using SimpleCrud.Core.ValueObjects;

namespace SimpleCrud.Application.Dtos;

public record PhoneDto
(
    Id Id,
    Name Name,
    PhoneNumber PhoneNumber
);