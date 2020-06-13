using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Vita.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "Vita API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "vita.spa",
                    ClientName = "SPA (Code + PKCE)",

                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris = { "http://localhost:4200" },
                    PostLogoutRedirectUris = { },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api"
                    },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                }
            };
        }
    }
}
