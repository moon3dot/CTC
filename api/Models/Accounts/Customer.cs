namespace api.Models.Accounts;

public record Customer(
     [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
     string? Id,
     [MaxLength(20),MinLength(12),Required(ErrorMessage = "This file is required")]
     string Phone,
     [MaxLength(20),MinLength(12),Required(ErrorMessage = "This file is required")]
     string FullName,
     [MaxLength(20),MinLength(12),Required(ErrorMessage = "This file is required"),DataType(DataType.Password)]
     byte[] FinalPassword,
     byte[] SaltKey
);