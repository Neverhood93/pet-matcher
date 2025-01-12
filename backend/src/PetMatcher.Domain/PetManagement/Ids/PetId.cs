namespace PetMatcher.Domain.PetManagement.Ids;

public sealed record PetId: IComparable<PetId>
{
    public Guid Value { get; }
    
    private PetId(Guid value)
    {
        Value = value;
    }
    
    public static PetId CreateNewId(Guid id) => new(id);

    public static PetId Empty() => new(Guid.Empty);
    
    public int CompareTo(PetId? other)
    {
        return other == null ? 1 : Value.CompareTo(other.Value);
    }
}