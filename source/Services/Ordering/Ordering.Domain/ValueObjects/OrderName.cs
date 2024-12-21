namespace Ordering.Domain.ValueObjects;

public class OrderName
{
    private const int DefaultLength = 6;
    public string Value { get; }
    private OrderName(string value) => Value = value;

    public static OrderName Of(string value) {

        ArgumentNullException.ThrowIfNullOrEmpty(value);
        ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, DefaultLength); 

        return new OrderName(value);
    }
}
