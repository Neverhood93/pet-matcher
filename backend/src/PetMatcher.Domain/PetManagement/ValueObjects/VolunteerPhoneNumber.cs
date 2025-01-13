using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public class VolunteerPhoneNumber: ComparableValueObject
{
    public string Value { get; }

    private VolunteerPhoneNumber(string value)
    {
        Value = value;
    }

    public static Result<VolunteerPhoneNumber> Create(string value)
    {
        var validationResult = Validate(value);
        return validationResult.IsFailure 
            ? Result.Failure<VolunteerPhoneNumber>(validationResult.Error) 
            : Result.Success(new VolunteerPhoneNumber(value));
    }
    
    private static Result Validate(string description)
    {
        return string.IsNullOrWhiteSpace(description) ? 
            Result.Failure("Phone number cannot be empty") :
            Result.Success();
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}