using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.Ids;

public sealed class PetId: ComparableValueObject
{
    public Guid Value { get; }
    
    private PetId(Guid value)
    {
        Value = value;
    }
    
    public static PetId CreateNewId(Guid id) => new(id);

    public static PetId Empty() => new(Guid.Empty);
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}