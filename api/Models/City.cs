namespace api.Models;

public record City(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    string StateName //gharare cities faghat dar db save beshan
);
