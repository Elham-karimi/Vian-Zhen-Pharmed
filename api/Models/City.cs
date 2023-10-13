namespace api.Models;

public record City(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    [MinLength(2),MaxLength(30)] string StateName
);
