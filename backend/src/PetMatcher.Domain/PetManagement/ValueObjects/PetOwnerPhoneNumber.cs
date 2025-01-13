using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public class PetOwnerPhoneNumber: ComparableValueObject
{
    public string Value { get; }

    private PetOwnerPhoneNumber(string value)
    {
        Value = value;
    }

    public static Result<PetOwnerPhoneNumber> Create(string value)
    {
        var validationResult = Validate(value);
        return validationResult.IsFailure 
            ? Result.Failure<PetOwnerPhoneNumber>(validationResult.Error) 
            : Result.Success(new PetOwnerPhoneNumber(value));
    }
    
    private static Result Validate(string description)
    {
        return string.IsNullOrWhiteSpace(description) ? 
            Result.Failure("Owner phone number cannot be empty") :
            Result.Success();
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}