using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.SpeciesManagement.Ids;

public sealed class BreedId: ComparableValueObject
{
    public Guid Value { get; }
    
    private BreedId(Guid value)
    {
        Value = value;
    }
    
    public static BreedId CreateNewId(Guid id) => new(id);

    public static BreedId Empty() => new(Guid.Empty);
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}