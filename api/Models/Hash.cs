namespace api.Models;

public record Hash
(
     byte[] Password,
     byte[] Salt
);
