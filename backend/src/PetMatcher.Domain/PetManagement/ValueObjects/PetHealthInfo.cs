using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public class PetHealthInfo: ComparableValueObject
{
    public string Value { get; }

    private PetHealthInfo(string value)
    {
        Value = value;
    }

    public static Result<PetHealthInfo> Create(string value)
    {
        var validationResult = Validate(value);
        return validationResult.IsFailure 
            ? Result.Failure<PetHealthInfo>(validationResult.Error) 
            : Result.Success(new PetHealthInfo(value));
    }
    
    private static Result Validate(string description)
    {
        return string.IsNullOrWhiteSpace(description) ? 
            Result.Failure("HealthInfo cannot be empty") :
            Result.Success();
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}