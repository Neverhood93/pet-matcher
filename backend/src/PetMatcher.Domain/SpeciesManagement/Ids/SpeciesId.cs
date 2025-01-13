using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.SpeciesManagement.Ids;

public sealed class SpeciesId: ComparableValueObject
{
    public Guid Value { get; }
    
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    
    public static SpeciesId CreateNewId(Guid id) => new(id);

    public static SpeciesId Empty() => new(Guid.Empty);
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}