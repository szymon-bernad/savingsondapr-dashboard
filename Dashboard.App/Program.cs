using Dashboard.App;
using Dashboard.App.CustomAuth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomAuthMessageHandler>(svc =>
{
    var authUrls = new List<string>
    {
        builder.HostEnvironment.BaseAddress,
        "http://localhost:5170"
    };
    return new CustomAuthMessageHandler(authUrls, svc.GetRequiredService<IAccessTokenProvider>(),
        svc.GetRequiredService<NavigationManager>());
});
builder.Services.AddHttpClient("Dashboard.API", client => client.BaseAddress = new Uri("http://localhost:5170"))
            .AddHttpMessageHandler<CustomAuthMessageHandler>();

        // Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Dashboard.API"));

builder.Services.AddMsalAuthentication<RemoteAuthenticationState, CustomAccount>(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://6d0aad49-2334-4353-9481-216f6c931969/user_impersonation");
    options.UserOptions.RoleClaim = "role";
})
.AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomAccount,
        CustomAccountFactory>();

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
