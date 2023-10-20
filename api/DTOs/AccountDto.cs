namespace api.DTOs;

public record RegisterDto(
    [MaxLength(50), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="Bad Email Format.")] string Email,
    [DataType(DataType.Password), MinLength(7), MaxLength(20)] string Password,
    [DataType(DataType.Password), MinLength(7), MaxLength(20)] string ConfirmPassword,
    City City // User dar hengame sabte nam shahresh ro ham entekhab mikone
);

public record LoginDto(
    string Email,
    string Password
);

