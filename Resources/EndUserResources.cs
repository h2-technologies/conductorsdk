using System.Net.Http.Json;
using System.Text.Json.Serialization;
using ConductorSdk.Exceptions;
using ConductorSdk.Models;

namespace ConductorSdk.Resources;

public class EndUsers
{
    private readonly HttpClient _client;
    public EndUsers(HttpClient httpClient)
    {
        _client = httpClient;
    }
    /// <summary>
    /// Sends a request directly to the specified integration on behalf of the end-user.
    /// </summary>
    /// <param name="integrationSlug">The integration identifier for the end-user's connection</param>
    /// <param name="endUserId">The ID of the end-user who owns the integration connection</param>
    /// <param name="qbdPayload">The request body to send to the integration connection</param>
    /// <returns></returns>
    /// <exception cref="ConductorApiException"></exception>
	public async Task Passthrough(IntegrationSlug integrationSlug, string endUserId, object qbdPayload, CancellationToken cancellationToken = default)
	{
        using var request = new HttpRequestMessage(HttpMethod.Post, $"/v1/end-users/{endUserId}/passthrough/{integrationSlug}")
        {
            Content = JsonContent.Create(qbdPayload)
        };

        using var response = await _client.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            try
            {
                var errorEnvelope = await response.Content.ReadFromJsonAsync<ConductorErrorContainer>(cancellationToken: cancellationToken);

                if (errorEnvelope?.Error != null)
                {
                    throw new ConductorApiException(errorEnvelope.Error);
                }
            }
            catch( Exception ex) when (ex is not ConductorApiException)
            {
                // Failsafe
            }

            //Fallback: Throws standard HTTP exception is JSON parsing failed entirely
            response.EnsureSuccessStatusCode();

        }
	}
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum IntegrationSlug
{
    [JsonPropertyName("quickbooks_desktop")]
    QuickbooksDesktop
}