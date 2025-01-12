using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public record SocialNetwork
{
    public string Name { get; }
    public string Link { get; }

    private SocialNetwork(string name, string link)
    {
        Name = name;
        Link = link;
    }
    
    public static Result<SocialNetwork> Create(string name, string link)
    {
        var validationResult = Validate(name, link);
        return validationResult.IsFailure 
            ? Result.Failure<SocialNetwork>(validationResult.Error) 
            : Result.Success(new SocialNetwork(name, link));
    }

    private static Result Validate(string name, string link)
    {
        return string.IsNullOrWhiteSpace(name) ? Result.Failure("Name cannot be empty") :
            string.IsNullOrWhiteSpace(link) ? Result.Failure("Link cannot be empty") :
            Result.Success();
    }
}