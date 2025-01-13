using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.Ids;

public sealed class VolunteerId: ComparableValueObject
{
    public Guid Value { get; }
    
    private VolunteerId(Guid value)
    {
        Value = value;
    }
    
    public static VolunteerId CreateNewId(Guid id) => new(id);

    public static VolunteerId Empty() => new(Guid.Empty);
    
    public int CompareTo(VolunteerId? other)
    {
        return other == null ? 1 : Value.CompareTo(other.Value);
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}