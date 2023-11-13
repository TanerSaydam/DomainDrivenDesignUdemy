namespace DomainDrivenDesignUdemy.Domain.Users;
public interface IUserRepository
{
    Task<User> CreateAsync(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress, CancellationToken cancellationToken = default);

    Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
}
