
using MediaBrowser.Common.Plugins;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.ProvidersIdSearch;


public class ProvidersIdSearchPlugin : BasePlugin<PluginConfiguration>
{

    public ProvidersIdSearchPlugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
    }

    private Guid _guid = Guid.Parse("35e94cd5-63be-4fad-98a7-b4b9bf0471fe");

    public override string Name => "Providers Id Search Plugin";

    public override Guid Id => _guid;

    public static ProvidersIdSearchPlugin? Instance { get; private set; }
}

