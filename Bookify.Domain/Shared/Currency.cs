namespace Bookify.Domain.Shared;

public record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Real = new("Real");
    public static readonly Currency Usd = new("USD");
    private Currency(string currencyCode) => Code = currencyCode;
    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
        return All.First(x => x.Code == code) ?? throw new ApplicationException("The currency code is invalid");
    }

    public static readonly IReadOnlyCollection<Currency> All =
    [
        Real,
        Usd
    ];
}
