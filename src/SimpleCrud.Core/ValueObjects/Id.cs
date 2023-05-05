using SimpleCrud.Core.Exceptions;

namespace SimpleCrud.Core.ValueObjects;

public sealed record Id
{
    public Guid Value { get; }

    public Id(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(Id date)
        => date.Value;

    public static implicit operator Id(Guid value)
        => new(value);

    public override string ToString() => Value.ToString("N");
}