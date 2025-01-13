using CSharpFunctionalExtensions;

namespace PetMatcher.Domain.PetManagement.ValueObjects;

public class PetDimensions: ComparableValueObject
{
    public double Weight { get; }
    public double Height { get; }

    private PetDimensions(double weight, double height)
    {
        Weight = weight;
        Height = height;
    }

    public static Result<PetDimensions> Create(double weight, double height)
    {
        var validationResult = Validate(weight, height);
        return validationResult.IsFailure 
            ? Result.Failure<PetDimensions>(validationResult.Error) 
            : Result.Success(new PetDimensions(weight, height));
    }

    private static Result Validate(double weight, double height)
    {
        return weight <= 0 ? Result.Failure("Weight must be positive value") :
            height <= 0 ? Result.Failure("Height must be positive value") :
            Result.Success();
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Weight;
        yield return Height;
    }
}