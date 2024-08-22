using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace DuendeIdentityServer;

public static class Config
{
	public static IEnumerable<IdentityResource> IdentityResources =>
		new IdentityResource[]
		{
			new IdentityResources.OpenId(),
			new IdentityResources.Profile(),
			new IdentityResource(
				name: "user",
				userClaims: new[] { JwtClaimTypes.Email }),
			new IdentityResource(
				name: "role",
				userClaims: new[] { JwtClaimTypes.Role }),
			new IdentityResource(
				name: "firstName",
				userClaims: new[] { "firstName" }),
			new IdentityResource(
				name: "lastName",
				userClaims: new[] { "lastName" }),
		};

	public static IEnumerable<ApiScope> ApiScopes =>
		new ApiScope[]
		{
			new ApiScope("api1")
		};

	public static IEnumerable<Client> Clients =>
		new Client[]
		{
			new Client
			{
				ClientId = "swagger",
				ClientName = "Client for Swagger use",

				AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
				ClientSecrets = { new Secret("secret".Sha256()) },
				AllowedScopes =
				{
					"api1",
					"openid",
					"profile"
				},
				AlwaysSendClientClaims = true,
				AlwaysIncludeUserClaimsInIdToken = true,
				AllowAccessTokensViaBrowser = true,
				RedirectUris =
				{
					$"{API_URL()}/swagger/oauth2-redirect.html"
				},
				AllowedCorsOrigins =
				{
					$"{API_URL()}",
					"https://localhost:5001",
				},
				Enabled = true
			},
			new Client
			{
				ClientId = "react",
				ClientName = "Client for React use",
				AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
				RequirePkce = true,
				RequireClientSecret = false,
				AllowedScopes =
				{
					"api1",
					"openid",
					"profile"
				},
				AllowedCorsOrigins = { "http://localhost:5173", "https://localhost:5001", "https://localhost:6001" },
				RedirectUris = { "http://localhost:5173/authentication/login-callback" },
				PostLogoutRedirectUris = { "http://localhost:5173/" }
			},
		};

	private static string API_URL()
	{
		return string.IsNullOrEmpty(Environment.GetEnvironmentVariable("API_URL"))
			? "https://localhost:6001"
			: Environment.GetEnvironmentVariable("API_URL");
	}
}