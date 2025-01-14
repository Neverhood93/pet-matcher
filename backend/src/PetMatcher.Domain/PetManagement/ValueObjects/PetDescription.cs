using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public class PetDescription: ComparableValueObject
{
    public string Value { get; }

    private PetDescription(string value)
    {
        Value = value;
    }

    public static Result<PetDescription> Create(string value)
    {
        var validationResult = Validate(value);
        return validationResult.IsFailure 
            ? Result.Failure<PetDescription>(validationResult.Error) 
            : Result.Success(new PetDescription(value));
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