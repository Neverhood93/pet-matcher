using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public record PetAddress
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string PostalCode { get; }

    private PetAddress(string street, string city, string state, string postalCode)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
    }

    public static Result<PetAddress> Create(string street, string city, string state, string postalCode)
    {
        var validationResult = Validate(street, city, state, postalCode);
        return validationResult.IsFailure 
            ? Result.Failure<PetAddress>(validationResult.Error) 
            : Result.Success(new PetAddress(street, city, state, postalCode));
    }

    private static Result Validate(string street, string city, string state, string postalCode)
    {
        return string.IsNullOrWhiteSpace(street) ? Result.Failure("Street cannot be empty") :
            string.IsNullOrWhiteSpace(city) ? Result.Failure("City cannot be empty") :
            string.IsNullOrWhiteSpace(state) ? Result.Failure("State cannot be empty") :
            string.IsNullOrWhiteSpace(postalCode) ? Result.Failure("PostalCode cannot be empty") :
            Result.Success();
    }
}