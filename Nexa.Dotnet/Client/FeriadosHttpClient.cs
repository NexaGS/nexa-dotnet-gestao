namespace Nexa.Dotnet.Client;

public class FeriadosHttpClient : IFeriadosHttpClient
{
    private readonly HttpClient _httpClient;

    public FeriadosHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IReadOnlyList<FeriadoResponse>> ObterFeriadosPorAnoAsync(int ano, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
