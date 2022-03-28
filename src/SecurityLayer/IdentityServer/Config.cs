using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer;

public class Config
{
    public static IEnumerable<Client> Clients =>
        new[]
        {
            new Client
            {
                ClientId = "clientAccess",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("clientAccess".Sha256())
                },
                AllowedScopes = {"catalogApi", "basketApi", "homepageAggregator"}
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new[]
        {
            new ApiScope("catalogApi", "Catalog API"),
            new ApiScope("basketApi", "Basket API"),
            new ApiScope("homepageAggregator", "HomePage Aggregator")
        };

    // public static IEnumerable<ApiResource> ApiResources =>
    //     new ApiResource[]
    //         { };
    //
    // public static IEnumerable<IdentityResource> IdentityResources =>
    //     new[] { };

    public static List<TestUser> TestUsers =>
        new();
}