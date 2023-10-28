namespace api.Models;

public record Hash
(
byte[] PasswordHash,
     byte[] Salt
);
