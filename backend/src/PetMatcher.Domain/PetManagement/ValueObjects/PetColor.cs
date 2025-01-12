using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public record PetColor
{
    public string Value { get; }

    private PetColor(string value)
    {
        Value = value;
    }

    public static Result<PetColor> Create(string value)
    {
        var validationResult = Validate(value);
        return validationResult.IsFailure 
            ? Result.Failure<PetColor>(validationResult.Error) 
            : Result.Success(new PetColor(value));
    }
    
    private static Result Validate(string description)
    {
        return string.IsNullOrWhiteSpace(description) ? 
            Result.Failure("Color cannot be empty") :
            Result.Success();
    }
}