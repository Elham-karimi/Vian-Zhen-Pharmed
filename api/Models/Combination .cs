namespace api.Models;

public record Combination(
    [MinLength(1),MaxLength(100)] string TypeOfCombination,
    [MinLength(1),MaxLength(1000)] Dictionary<string,string> Title
    // [MinLength(1),MaxLength(1000)] List<string> Amount
);
