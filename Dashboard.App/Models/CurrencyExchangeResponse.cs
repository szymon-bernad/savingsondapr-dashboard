namespace Dashboard.App.Models;

public record CurrencyExchangeResponse(decimal Rate, string ExchangeType, DateTime Timestamp);
