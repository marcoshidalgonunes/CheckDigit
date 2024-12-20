using System.Globalization;
using System.Resources;

namespace CheckDigit.Documento;

internal class ResourcesFacade
{
    private static readonly ResourceManager _resourceManager = new("CheckDigit.Documento.Resources.Messages", typeof(ResourcesFacade).Assembly);

    internal static string? GetString(string name) => _resourceManager?.GetString(name, culture: CultureInfo.CurrentUICulture);
}

