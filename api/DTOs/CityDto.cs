namespace api.DTOs;

public record CityDto(
 [MinLength(2), MaxLength(50)] string StateName
);

