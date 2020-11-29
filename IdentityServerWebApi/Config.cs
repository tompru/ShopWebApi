using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerWebApi
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource
                {
                    Name = "WebApi",
                    DisplayName = "Shop Web Api",
                    ApiSecrets = {new Secret("198370-xxxx-9387S%&@!#(18".Sha256())},
                    Scopes = new List<string>()
                    {
                        "WebApi.read", "WebApi.write", "WebApi.full"
                    }
                },
                new ApiResource("TotalPriceApi")
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
             {
                 new ApiScope(name: "WebApi.read",   displayName: "Web Api - Read your data."),
                 new ApiScope(name: "WebApi.write",  displayName: "Web Api - Write your data."),
                 new ApiScope(name: "WebApi.full", displayName: "Web Api - Full access."),
                 new ApiScope(name: "TotalPriceApi", displayName: "TotalPriceApi scope.")
             };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "WebApiTestApp",
                    ClientId = "#77s1!7jSJ6ct6BAsg6(98&%45d",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("999129837-1298376=19812398@!%".Sha256())},
                    AllowedScopes = new List<string>()
                    {
                        "WebApi.read", "WebApi.write", "WebApi.full"
                    }
                },
                new Client
                {
                    ClientName = "ConsoleTestApp",
                    ClientId = "111222333444555666777888999",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("919841897SJAKDASM13jh8@!%".Sha256())},
                    AllowedScopes = new List<string>()
                    {
                        "TotalPriceApi"
                    }
                }
            };
        }
    }
}
