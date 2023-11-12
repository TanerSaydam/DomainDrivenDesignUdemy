namespace DomainDrivenDesignUdemy.Domain.Users;

public sealed record Address(
    string Country,
    string City,
    string Street,
    string FullAddress,
    string PostalCode);
