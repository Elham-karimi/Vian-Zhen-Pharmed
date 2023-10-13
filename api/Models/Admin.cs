
namespace api.Models;

public record Admin(
     [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
     [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="Bad Email Format.")] string Email,
     [MinLength(3), MaxLength(50)] string Password,
     [MinLength(3), MaxLength(50)] string? ConfirmPassword
);
