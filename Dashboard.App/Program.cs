using Dashboard.App;
using Dashboard.App.CustomAuth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.AddJsonFile("appsettings.json");

var cfgBaseUrl = builder.Configuration.GetValue<string>("Dashboard:BaseUrl") ?? "http://localhost:5170";
var cfgDefaultScope = builder.Configuration.GetValue<string>("Dashboard:DefaultScope") ??
                throw new ArgumentNullException("Dashboard:DefaultScope");

builder.Services.AddTransient<CustomAuthMessageHandler>(svc =>
{
    var authUrls = new List<string>
    {
        builder.HostEnvironment.BaseAddress,
        cfgBaseUrl
    };
    return new CustomAuthMessageHandler(
        authUrls,
        [cfgDefaultScope],
        svc.GetRequiredService<IAccessTokenProvider>(),
        svc.GetRequiredService<NavigationManager>());
});

builder.Services.AddHttpClient("Dashboard.API",
                                client => client.BaseAddress = new Uri(cfgBaseUrl))
                 .AddHttpMessageHandler<CustomAuthMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Dashboard.API"));

builder.Services.AddMsalAuthentication<RemoteAuthenticationState, CustomAccount>(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.UserOptions.RoleClaim = "role";

})
.AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomAccount, CustomAccountFactory>();


builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
