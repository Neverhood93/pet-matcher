using CSharpFunctionalExtensions;
using PetMatcher.Domain.SpeciesManagement.Ids;

namespace PetMatcher.Domain.SpeciesManagement.Entities;

public class Breed : Entity<BreedId>
{
    public BreedId Id { get; private set; }
    public string Name { get; private set; }

    // For EF Core
    private Breed() { }

    public Breed(BreedId id, string name)
        : base(id)
    {
        Id = id;
        Name = name;
    }
}