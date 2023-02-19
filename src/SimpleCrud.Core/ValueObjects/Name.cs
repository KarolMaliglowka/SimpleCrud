using SimpleCrud.Core.Exceptions;

namespace SimpleCrud.Core.ValueObjects;

public record Name(string Value)
{
    public string Value { get; } = Value ?? throw new InvalidNameException();

    public static implicit operator string(Name name)
        => name.Value;

    public static implicit operator Name(string value)
        => new(value);
}