namespace DomainDrivenDesignUdemy.Domain.Users;

public sealed record Password
{
    public string Value { get; init;  }
    public Password(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("İsim alanı boş olamaz!");
        }

        if (value.Length < 6)
        {
            throw new ArgumentException("İsim alanı 6 karakterden küçük olamaz!");
        }        

        Value = value;
    }
}
