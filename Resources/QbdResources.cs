using System.Net.Http.Json;
using ConductorSdk.Exceptions;
using ConductorSdk.Models;

namespace ConductorSdk.Resources;

public class QbdResource
{
    private readonly HttpClient _client;
    public TransactionsResource TransactionsResource;
    public QbdResource(HttpClient httpClient)
    {
        _client = httpClient;
        TransactionsResource = new TransactionsResource(_client);
        //TODO: Fill with resource engines as properties
      
    }

    /// <summary>
    /// Checks whether the specified QuickBooks Desktop connection is active and can process requests end-to-end.
    /// </summary>
    /// <param name="ConductorEndUserId">The ID of the End-User to receive this request.</param>
    /// <returns>An object with the duration of the health check in milliseconds. Returns an error if the health check fails.</returns>
    public async Task<(int Duration, string Status)> HealthCheck(string conductorEndUserId, CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "/v1/quickbooks-desktop/health-check");

        request.Headers.Add("Conductor-End-User-Id", conductorEndUserId);

        using var response = await _client.SendAsync(request, cancellationToken);
        
        if(!response.IsSuccessStatusCode)
        {
            try
            {
                var errorEnvelope = await response.Content.ReadFromJsonAsync<ConductorErrorContainer>(cancellationToken: cancellationToken);

                if (errorEnvelope?.Error != null)
                {
                    throw new ConductorApiException(errorEnvelope.Error);
                }
            }
            catch (Exception ex) when (ex is not ConductorApiException)
            {
                // Failsafe
            }


            //Fallback: Throws standard HTTP exception is JSON parsing failed entirely
            response.EnsureSuccessStatusCode();
        }

        return await response.Content.ReadFromJsonAsync<(int duration, string status)>(cancellationToken: cancellationToken);
    }

}