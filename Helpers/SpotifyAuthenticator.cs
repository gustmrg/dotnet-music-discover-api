using System.Text.Json.Serialization;
using RestSharp;
using RestSharp.Authenticators;

namespace MusicDiscover.Api.Helpers;

public class SpotifyAuthenticator : AuthenticatorBase
{
    private readonly string _baseUrl;
    private readonly string _clientId;
    private readonly string _clientSecret;

    public SpotifyAuthenticator(string baseUrl, string clientId, string clientSecret) : base("")
    {
        _baseUrl = baseUrl;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }


    protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
    {
        Token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
        return new HeaderParameter(KnownHeaders.Authorization, Token);
    }
    
    async Task<string> GetToken() {
        var options = new RestClientOptions(_baseUrl);
        using var client = new RestClient(options) {
            Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret),
        };

        var request = new RestRequest("oauth2/token")
            .AddParameter("grant_type", "client_credentials");
        var response = await client.PostAsync<TokenResponse>(request);
        return $"{response!.TokenType} {response!.AccessToken}";
    }
    
    public static string Base64Encode(string plainText) {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    
    public record TokenResponse {
        [JsonPropertyName("token_type")]
        public string TokenType { get; init; }
        
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; }
        
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; init; }
    }
}