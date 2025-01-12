using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public record VolunteerFullName
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Patronymic { get; }

    private VolunteerFullName(string firstName, string lastName, string patronymic)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }

    public static Result<VolunteerFullName> Create(string firstName, string lastName, string patronymic)
    {
        var validationResult = Validate(firstName, lastName);
        return validationResult.IsFailure 
            ? Result.Failure<VolunteerFullName>(validationResult.Error) 
            : Result.Success(new VolunteerFullName(firstName, lastName, patronymic));
    }

    private static Result Validate(string firstName, string lastName)
    {
        return string.IsNullOrWhiteSpace(firstName) ? Result.Failure("Firstname cannot be empty") :
            string.IsNullOrWhiteSpace(lastName) ? Result.Failure("Lastname cannot be empty") :
            Result.Success();
    }
}