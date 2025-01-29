using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;

namespace Dashboard.App;

public class CustomAuthMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthMessageHandler(IEnumerable<string> authUrls, IAccessTokenProvider provider,
        NavigationManager navigation)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: authUrls);
    }
}
