namespace OneSale.Domain.ValueObjects;

public sealed class Quantity : IEquatable<Quantity>
{
    public int Value { get; }
    private Quantity(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
        Value = value;
    }
    public static Quantity From(int value) => new Quantity(value);
    public bool Equals(Quantity? other) =>
        other is not null && Value == other.Value;
    public override bool Equals(object? obj) =>
        obj is Quantity other && Equals(other);
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();
}