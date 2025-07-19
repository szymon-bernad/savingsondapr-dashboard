namespace Dashboard.App.Models;

public record CurrentAccountDto
{
    public required string UserId { get; set; }

    public required string ExternalRef { get; set; }

    public Currency AccountCurrency { get; set; } = Currency.USD;
}
