using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public record VolunteerEmail
{
    private const string EMAIL_REGEX = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    
    public string Value { get; }

    private VolunteerEmail(string value)
    {
        Value = value;
    }

    public static Result<VolunteerEmail> Create(string value)
    {
        var validationResult = Validate(value);
        return validationResult.IsFailure 
            ? Result.Failure<VolunteerEmail>(validationResult.Error) 
            : Result.Success(new VolunteerEmail(value));
    }
    
    private static Result Validate(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? Result.Failure("Email cannot be empty") :
            !Regex.IsMatch(value, EMAIL_REGEX) ? Result.Failure("Email is not valid") :
            Result.Success();
    }
}