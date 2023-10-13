namespace api.Models;

public record Product(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    [MinLength(1),MaxLength(100)] string Name,
    [MinLength(1),MaxLength(1000)] string ShortDescription,
    SpecificSpecification SpecificSpecification
);
public record SpecificSpecification(
    [MinLength(1),MaxLength(300)] string ProductType,
    [MinLength(1),MaxLength(300)] string ConsumerGroup,
    [MinLength(1),MaxLength(1000)] string UsageCases,
    [MinLength(1),MaxLength(300)] string Dosage,
    [MinLength(1),MaxLength(2000)] string Combination
);