namespace DomainDrivenDesignUdemy.Domain.Shared;

public sealed record Name
{
    public string Value { get; init; }
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("İsim alanı boş olamaz!");
        }


        if (value.Length < 3)
        {
            throw new ArgumentException("İsim alanı 3 karakterden küçük olamaz!");
        }


        Value = value;
    }
}
