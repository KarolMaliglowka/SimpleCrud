using System.Text.RegularExpressions;
using SimpleCrud.Core.Exceptions;

namespace SimpleCrud.Core.ValueObjects;

public partial record PhoneNumber
{
    private static readonly Regex Regex = MyRegex();

    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidPhoneNumberException(value);
        }

        if (value.Length > 12)
        {
            throw new InvalidPhoneNumberException(value);
        }

        // value = value.ToLowerInvariant();
        // if (!Regex.IsMatch(value))
        // {
        //     throw new InvalidPhoneNumberException(value);
        // }

        Value = value;
    }

    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;

    public static implicit operator PhoneNumber(string phoneNumber) => new(phoneNumber);

    public override string ToString() => Value;

    [GeneratedRegex("^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}