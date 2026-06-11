using System.Net.Http.Headers;
using ConductorSdk.Resources;

namespace ConductorSdk;

public class ConductorClient : IDisposable
{
	private readonly HttpClient _httpClient;

	public QbdResource Qbd { get; }

	public ConductorClient(string apiKey)
	{
		_httpClient = new(){ BaseAddress = new Uri("https://api.conductor.is/") };
		_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
		_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		Qbd = new QbdResource(_httpClient);

	}

	public void Dispose()
	{
		_httpClient.Dispose();
		GC.SuppressFinalize(this);
	}
}