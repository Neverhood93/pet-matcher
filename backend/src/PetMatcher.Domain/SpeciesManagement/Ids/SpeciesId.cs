namespace PetMatcher.Domain.SpeciesManagement.Ids;

public sealed record SpeciesId: IComparable<SpeciesId>
{
    public Guid Value { get; }
    
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    
    public static SpeciesId CreateNewId(Guid id) => new(id);

    public static SpeciesId Empty() => new(Guid.Empty);
    
    public int CompareTo(SpeciesId? other)
    {
        return other == null ? 1 : Value.CompareTo(other.Value);
    }
}