using CSharpFunctionalExtensions;
using PetMatcher.Domain.PetManagement.Enums;
using PetMatcher.Domain.PetManagement.Ids;
using PetMatcher.Domain.PetManagement.ValueObjects;
using PetMatcher.Domain.SpeciesManagement.Ids;

namespace PetMatcher.Domain.PetManagement.Entities;

public class Pet: Entity<PetId>
{
    public PetId Id { get; private set; }
    public PetName Name { get; private set; }
    public SpeciesId SpeciesId { get; private set; }
    public PetDescription Description { get; private set; }
    public BreedId BreedId { get; private set; }
    public PetColor Color { get; private set; }
    public PetHealthInfo HealthInfo { get; private set; }
    public PetAddress Address { get; private set; }
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public PetOwnerPhoneNumber OwnerPhoneNumber { get; private set; }
    public bool IsCastrated { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool IsVaccinated { get; private set; }
    public PetStatus Status { get; private set; }
    public List<PaymentDetail> PaymentDetails { get; private set; }
    public DateTime CreatedOn { get; private set; }
    
    // For EF Core
    private Pet() { }

    public Pet(PetId id, 
        PetName name, 
        SpeciesId speciesId, 
        PetDescription description,
        BreedId breedId, 
        PetColor color, 
        PetHealthInfo healthInfo, 
        PetAddress address, 
        double weight, 
        double height,
        PetOwnerPhoneNumber ownerPhoneNumber, 
        bool isCastrated, 
        DateTime birthDate, 
        bool isVaccinated, 
        PetStatus status, 
        List<PaymentDetail> paymentDetails, 
        DateTime createdOn) : base(id)
    {
        Id = id;
        Name = name;
        SpeciesId = speciesId;
        Description = description;
        BreedId = breedId;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        OwnerPhoneNumber = ownerPhoneNumber;
        IsCastrated = isCastrated;
        BirthDate = birthDate;
        IsVaccinated = isVaccinated;
        Status = status;
        PaymentDetails = paymentDetails;
        CreatedOn = createdOn;
    }
}