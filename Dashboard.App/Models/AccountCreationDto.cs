using SavingsOnDapr.Dashboard.Client.Models;


namespace Dashboard.App.Models;

public class AccountCreationDto
{
    public string ExternalRef { get; set; }
    public string UserId { get; set; }
    public AccountType Type { get; set; } = AccountType.CurrentAccount;
    public Currency AccountCurrency { get; set; } = Currency.EUR;
    public decimal? InterestRate { get; set; }
    public string InterestRateString => InterestRate.HasValue ? $"{(InterestRate.Value * 100m).ToString("0.0000")} %" : string.Empty;
    public string? CurrentAccountRef { get; set; }
}
