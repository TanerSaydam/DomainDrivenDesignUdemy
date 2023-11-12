using System.Diagnostics.Tracing;

namespace DomainDrivenDesignUdemy.Domain.Shared;
public sealed record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("Usd");
    public static readonly Currency TRY = new("TRY");
    public string Code { get; init; }
    private Currency(string code)
    {
        Code = code;
    }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(p => p.Code == code) ??
            throw new ArgumentException("Geçerli bir para birimi girin!");
    }

    public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, TRY };
}
