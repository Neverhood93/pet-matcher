namespace PetMatcher.Domain.SpeciesManagement.Ids;

public sealed record BreedId: IComparable<BreedId>
{
    public Guid Value { get; }
    
    private BreedId(Guid value)
    {
        Value = value;
    }
    
    public static BreedId CreateNewId(Guid id) => new(id);

    public static BreedId Empty() => new(Guid.Empty);
    
    public int CompareTo(BreedId? other)
    {
        return other == null ? 1 : Value.CompareTo(other.Value);
    }
}