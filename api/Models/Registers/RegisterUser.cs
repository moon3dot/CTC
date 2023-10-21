namespace api.Models.Registers;

public record RegisterUser(
           string Phone,
           string FullName,
           string Password,
           string VerificationCode
);
