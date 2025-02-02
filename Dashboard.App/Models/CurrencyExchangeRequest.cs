namespace Dashboard.App.Models;

public record CurrencyExchangeRequest(
    string OrderId,
    string DebtorExternalRef,
    string BeneficiaryExternalRef,
    string SourceCurrency,
    string TargetCurrency,
    decimal SourceAmount);