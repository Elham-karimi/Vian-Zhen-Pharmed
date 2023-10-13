namespace api.Models;

public record Login(
     [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
     [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="Bad Email Format.")] string Email,
     [MinLength(8)] string Password
);
