using System.Text.Json.Serialization;

namespace Dashboard.App.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Currency
{
    EUR,
    USD,
    GBP,
    CHF,
    PLN,
    NOK,
    CAD,
}
