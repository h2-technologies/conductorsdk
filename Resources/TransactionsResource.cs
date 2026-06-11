using System.Net.Http.Json;
using ConductorSdk.Exceptions;
using ConductorSdk.Models;

namespace ConductorSdk.Resources;

public class TransactionsResource
{
    private readonly HttpClient _client;

    public TransactionsResource(HttpClient httpClient)
    {
        _client = httpClient;
    }

    /// <summary>
    /// <para>Retrieves a transaction by ID. </para>
    /// <para><b>IMPORTANT:</b> If you need to fetch multiple specific transactions by ID, use the list endpoint instead with the <c>ids</c> parameter.
    /// It accepts an array of IDs so you can batch the request into a single call, which is significantly faster.</para>
    /// </summary>
    /// 
    /// <param name="transactionId">The QuickBooks-assigned unique identifier of the transaction to retrieve.</param>
    /// <param name="conductorEndUserId">The ID of the End-User to recieve this request.</param>
    /// <returns>Returns the specified Transaction</returns>
    public async Task<Transaction> Retrieve(string transactionId, string conductorEndUserId, CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"/v1/quickbooks-desktop/transactions/{transactionId}");

        request.Headers.Add("Conductor-End-User-Id", conductorEndUserId);

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
            catch (Exception ex) when (ex is not ConductorApiException)
            {
                // Failsafe
            }

            response.EnsureSuccessStatusCode();
        }


        return await response.Content.ReadFromJsonAsync<Transaction>(cancellationToken: cancellationToken);

    }

       
}