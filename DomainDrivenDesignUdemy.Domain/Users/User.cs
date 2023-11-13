using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Shared;

namespace DomainDrivenDesignUdemy.Domain.Users;
public sealed class User : Entity
{
    private User(Guid id) : base(id)
    {

    }
    private User(Guid id, Name name, Email email, Password password, Address address) : base(id)
    {
        Name = name;
        Email = email;
        Password = password;
        Address = address;
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Address Address { get; private set; }

    public static User CreateUser(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress)
    {
        //İş Kuralları
        User user = new(
            id: Guid.NewGuid(),
            name: new(name),
            email: new(email),
            password: new(password),
            address: new(country, city, street, fullAddress, postalCode));

        return user;
            
    }

    public void ChangeName(string name)
    {
        Name = new(name);
    }

    public void ChangeAddress(string country, string city,string street, string postalCode, string fullAddress)
    {
        Address = new(country, city, street, fullAddress, postalCode);
    }

    public void ChangeEmail(string email)
    {
        Email = new(email);
    }

    public void ChangePassword(string password)
    {
        Password = new(password);
    }
}
