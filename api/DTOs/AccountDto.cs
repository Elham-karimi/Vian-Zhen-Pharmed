namespace api.DTOs;

public record RegisterDto(
    // Email
    [MaxLength(50), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage = "Bad Email Format.")] string Email,
    [DataType(DataType.Password), MinLength(7), MaxLength(20)] string Password,
    [DataType(DataType.Password), MinLength(7), MaxLength(20)] string ConfirmPassword,
    CityDto CityDto // User dar hengame sabte nam shahresh ro ham entekhab mikone
);

public record LoginDto(
    // Email
    [MaxLength(50), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage = "Bad Email Format.")] string Email,
    [DataType(DataType.Password), MinLength(7), MaxLength(20)] string Password
);

