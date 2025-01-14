using CSharpFunctionalExtensions;
using PetMatcher.Domain.SpeciesManagement.Ids;

namespace PetMatcher.Domain.SpeciesManagement.Entities;

public class Species : Entity<SpeciesId>
{
    public SpeciesId Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyList<Breed> Breeds { get; private set; }

    // For EF Core
    private Species() { }

    public Species(SpeciesId id, string name, List<Breed> breeds)
        : base(id)
    {
        Id = id;
        Name = name;
        Breeds = breeds;
    }
}