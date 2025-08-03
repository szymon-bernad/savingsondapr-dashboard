using System.Text.Json.Serialization;

namespace Dashboard.App.Models;

public record BankAccountDto
{
    [JsonPropertyName("externalRef")]
    public string AccountRef { get; init; }

    [JsonPropertyName("currency")]
    public string Currency { get; init; }

    [JsonPropertyName("totalBalance")]
    public decimal TotalBalance { get; init; }

    [JsonPropertyName("key")]
    public string AccountId { get; init; }

    [JsonPropertyName("type")]
    public string AccountType { get; init; }

    [JsonPropertyName("details")]
    public IDictionary<string, string>? Details { get; init; }

    public const string InterestRateKey = "InterestRate";

    public const string AccruedInterestKey = "AccruedInterest";

}
