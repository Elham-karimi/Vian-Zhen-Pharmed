namespace api.DTOs;

public record ProductDto(
    [MinLength(1),MaxLength(100)] string PersianName,
    [MinLength(1),MaxLength(100)] string EnglishName,
    [MinLength(1),MaxLength(1000)] string ShortDescription,
    [MinLength(1),MaxLength(1000)] string UsageCases,
    [MinLength(1),MaxLength(300)] string ProductType,
    [MinLength(1),MaxLength(300)] string ConsumerGroup,
    [MinLength(1),MaxLength(300)] string Dosage,
    Combination Combination
);




