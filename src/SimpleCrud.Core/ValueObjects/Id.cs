using SimpleCrud.Core.Exceptions;

namespace SimpleCrud.Core.ValueObjects;

public readonly struct Id
{
    private Guid Value { get;}

    private Id(Guid value)
    {
        if (value == Guid.Empty) 
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(Id id) => id.Value;
    public static implicit operator Id(Guid value) => new(value);
}