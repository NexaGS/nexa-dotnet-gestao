namespace Nexa.Dotnet.Client;

public interface IFeriadosHttpClient
{
    Task<IReadOnlyList<FeriadoResponse>> ObterFeriadosPorAnoAsync(int ano, CancellationToken cancellationToken = default);
}
