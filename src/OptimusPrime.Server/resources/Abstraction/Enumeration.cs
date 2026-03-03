using System.Reflection;

namespace OptimusPrime.Domain.Abstractions;

public abstract class Enumeration : IComparable
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }


    protected Enumeration(int id, string name, string description) => (Id, Name, Description) = (id, name, description);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                    .Select(f => f.GetValue(null))
                    .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
        var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
        return absoluteDifference;
    }

    public static T FromValue<T>(int value) where T : Enumeration
    {
        var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
        return matchingItem;
    }

    public static T FromDisplayName<T>(string displayName) where T : Enumeration
    {
        var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
        return matchingItem;
    }

    private static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        return matchingItem is null
            ? throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}")
            : matchingItem;
    }

    public int CompareTo(object? obj) => obj is null ? -1 : Id.CompareTo(((Enumeration)obj).Id);
    public static int Compare(Enumeration left, Enumeration right)
    {
        if (object.ReferenceEquals(left, right))
        {
            return 0;
        }
        if (left is null)
        {
            return -1;
        }
        return left.CompareTo(right);
    }
    public static bool operator == (Enumeration? left, Enumeration? right)
    {
        if (left is null)
        {
            return right is null;
        }
        return left.Equals(right);
    }
    public static bool operator > (Enumeration left, Enumeration right)
    {
        return Compare(left, right) > 0;
    }
    public static bool operator >= (Enumeration left, Enumeration right)
    {
        return Compare(left, right) >= 0;
    }
    public static bool operator < (Enumeration left, Enumeration right)
    {
        return Compare(left, right) < 0;
    }
    public static bool operator <= (Enumeration left, Enumeration right)
    {
        return Compare(left, right) <= 0;
    }
    public static bool operator != (Enumeration? left, Enumeration? right)
    {
        if (left is null)
        {
            return right is not null;
        }
        return !left.Equals(right);
    }
}
