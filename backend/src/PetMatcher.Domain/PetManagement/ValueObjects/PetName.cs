using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public class PetName: ComparableValueObject
{
    public string Value { get; }

    private PetName(string value)
    {
        Value = value;
    }

    public static Result<PetName> Create(string value)
    {
        var validationResult = Validate(value);
        return validationResult.IsFailure 
            ? Result.Failure<PetName>(validationResult.Error) 
            : Result.Success(new PetName(value));
    }
    
    private static Result Validate(string description)
    {
        return string.IsNullOrWhiteSpace(description) ? 
            Result.Failure("Name cannot be empty") :
            Result.Success();
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}