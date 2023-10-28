namespace api.DTOs;
public record RegisterDto(
     [MaxLength(15),MinLength(14),Required(ErrorMessage =("This Fild is required"))]
     string Phone,
     [MaxLength(20),MinLength(3),Required(ErrorMessage =("This Fild is required"))]
     string FullName,
     [DataType(DataType.Password), MinLength(7), MaxLength(20)]
     string Password,
     string VerificationCode
);

public record LoginDto(
     [MaxLength(15),MinLength(14),Required(ErrorMessage =("This Fild is required"))]
     string Phone,
     [MaxLength(20),MinLength(3),Required(ErrorMessage =("This Fild is required")),DataType(DataType.Password)]
     string Password
);