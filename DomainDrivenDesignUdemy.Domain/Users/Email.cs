namespace DomainDrivenDesignUdemy.Domain.Users;

public sealed record Email
{
    public string Value { get; init; }
    public Email(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("İsim alanı boş olamaz!");
        }

        if (value.Length < 3)
        {
            throw new ArgumentException("İsim alanı 3 karakterden küçük olamaz!");
        }

        if (!value.Contains("@"))
        {
            throw new ArgumentException("Geçerli bir mail adresi girin!");
        }

        Value = value;
    }
}
