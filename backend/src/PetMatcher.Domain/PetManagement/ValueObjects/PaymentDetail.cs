using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public record PaymentDetail
{
    public string Name { get; }
    public string Description { get; }

    private PaymentDetail(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    public static Result<PaymentDetail> Create(string name, string description)
    {
        var validationResult = Validate(name, description);
        return validationResult.IsFailure 
            ? Result.Failure<PaymentDetail>(validationResult.Error) 
            : Result.Success(new PaymentDetail(name, description));
    }

    private static Result Validate(string name, string description)
    {
        return string.IsNullOrWhiteSpace(name) ? Result.Failure("Name cannot be empty") :
            string.IsNullOrWhiteSpace(description) ? Result.Failure("Description cannot be empty") :
            Result.Success();
    }
}