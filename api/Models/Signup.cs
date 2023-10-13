namespace api.Models;

public record Signup(
     [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
     [MinLength(3), MaxLength(30)] string? Name,
     [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="Bad Email Format.")] string Email,
     [MinLength(8)] string Password,
     [MinLength(8)] string ConfirmPassword
);
