namespace api.Models;

public record Product(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    string PersianName,
    string EnglishName,
    string ShortDescription,
    string UsageCases,
    string ProductType,
    string ConsumerGroup,
    string Dosage,
    string TypeOfCombination,
    Combination Combination
    );

public record Combination(
    string Title,
    int Amount
    );

