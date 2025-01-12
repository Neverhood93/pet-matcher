using CSharpFunctionalExtensions;
using PetMatcher.Domain.PetManagement.Enums;
using PetMatcher.Domain.PetManagement.Ids;
using PetMatcher.Domain.PetManagement.ValueObjects;

namespace PetMatcher.Domain.PetManagement.Entities;

public class Volunteer: Entity<VolunteerId>
{
    List<Pet> _pets = new();

    public VolunteerId Id { get; private set; }
    public VolunteerFullName FullName { get; private set; }
    public VolunteerEmail Email { get; private set; }
    public VolunteerDescription Description { get; private set; }
    public int ExperienceInYears { get; private set; }
    public VolunteerPhoneNumber PhoneNumber { get; private set; }
    public List<SocialNetwork> SocialNetworks { get; private set; }
    public List<PaymentDetail> PaymentDetails { get; private set; }
    
    public List<Pet> Pets => _pets;
    
    // For EF Core
    private Volunteer() { }

    public Volunteer(VolunteerId id, 
        VolunteerFullName fullName, 
        VolunteerEmail email, 
        VolunteerDescription description,
        int experienceInYears, 
        VolunteerPhoneNumber phoneNumber, 
        List<SocialNetwork> socialNetworks, 
        List<PaymentDetail> paymentDetails) : base(id)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Description = description;
        ExperienceInYears = experienceInYears;
        PhoneNumber = phoneNumber;
        SocialNetworks = socialNetworks;
        PaymentDetails = paymentDetails;
    }
    
    public int FoundHomePetCount => _pets.Count(p => p.Status == PetStatus.FoundHome);
    
    public int LookingForHomePetCount => _pets.Count(p => p.Status == PetStatus.LookingForHome);
    
    public int NeedsHelpPetCount => _pets.Count(p => p.Status == PetStatus.NeedsHelp);
}