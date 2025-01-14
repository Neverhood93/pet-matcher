using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public class VolunteerDescription: ComparableValueObject
{
    public string Value { get; }

    private VolunteerDescription(string value)
    {
        Value = value;
    }

    public static Result<VolunteerDescription> Create(string value)
    {
        var validationResult = Validate(value);
        return validationResult.IsFailure 
            ? Result.Failure<VolunteerDescription>(validationResult.Error) 
            : Result.Success(new VolunteerDescription(value));
    }
    
    private static Result Validate(string description)
    {
        return string.IsNullOrWhiteSpace(description) ? 
            Result.Failure("Description cannot be empty") :
            Result.Success();
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}