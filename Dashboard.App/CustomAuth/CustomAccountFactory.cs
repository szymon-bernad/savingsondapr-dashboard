using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace Dashboard.App.CustomAuth;

public class CustomAccountFactory(
        IAccessTokenProviderAccessor accessor)
        : AccountClaimsPrincipalFactory<CustomAccount>(accessor)
{

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity is not null &&
            initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = initialUser.Identity as ClaimsIdentity;

            if (userIdentity is not null)
            {
                userIdentity.AddClaim(new Claim("oid", account?.Oid ?? string.Empty));
                account?.Roles?.ForEach((role) =>
                {
                    userIdentity.AddClaim(new Claim("role", role));
                });
            }
        }

        return initialUser;
    }
}
