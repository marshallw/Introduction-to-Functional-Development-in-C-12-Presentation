namespace Types;

public static class Option
{
    public static Some<T> Some<T>(T value) => new Some<T>(value);
    public static None<T> None<T>() => new None<T>();

    public static Option<T> ToOptional<T>(this T value) => new Some<T>(value);
}

public record Option<T>();

public sealed record Some<T> : Option<T>
{
    public T Value {get; init;}

    public Some(T value) => (Value) = (value);
}

public sealed record None<T>() : Option<T>;