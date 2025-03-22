// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using SavingsOnDapr.Dashboard.Client.Api.Currency;
using SavingsOnDapr.Dashboard.Client.Api.CurrencyExchangeSummary;
using SavingsOnDapr.Dashboard.Client.Api.Users;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace SavingsOnDapr.Dashboard.Client.Api
{
    /// <summary>
    /// Builds and executes requests for operations under \api
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class ApiRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The currency property</summary>
        public global::SavingsOnDapr.Dashboard.Client.Api.Currency.CurrencyRequestBuilder Currency
        {
            get => new global::SavingsOnDapr.Dashboard.Client.Api.Currency.CurrencyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The currencyExchangeSummary property</summary>
        public global::SavingsOnDapr.Dashboard.Client.Api.CurrencyExchangeSummary.CurrencyExchangeSummaryRequestBuilder CurrencyExchangeSummary
        {
            get => new global::SavingsOnDapr.Dashboard.Client.Api.CurrencyExchangeSummary.CurrencyExchangeSummaryRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The users property</summary>
        public global::SavingsOnDapr.Dashboard.Client.Api.Users.UsersRequestBuilder Users
        {
            get => new global::SavingsOnDapr.Dashboard.Client.Api.Users.UsersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::SavingsOnDapr.Dashboard.Client.Api.ApiRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApiRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/api", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::SavingsOnDapr.Dashboard.Client.Api.ApiRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApiRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/api", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
