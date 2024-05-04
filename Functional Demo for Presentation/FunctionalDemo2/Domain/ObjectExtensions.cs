using Types;

namespace Domain;

public static class OptionExtensions
{
    public static Option<TResult> Map<TInput, TResult>(this Option<TInput> option, Func<TInput, TResult> mapper) =>
        option is Some<TInput> s ? mapper(s.Value).ToOptional() : Option.None<TResult>();

    public static T Reduce<T>(this Option<T> option, T alternative) => option is Some<T> some ? some.Value : alternative;
    public static T Reduce<T>(this Option<T> option, Func<T> alternative) => option is Some<T> some ? some.Value : alternative();
}