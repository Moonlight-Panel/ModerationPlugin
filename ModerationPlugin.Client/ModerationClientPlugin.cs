using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModerationPlugin.Client.Implementations;
using ModerationPlugin.Client.Services;
using MoonCore.Extensions;
using Moonlight.Client.App.Interfaces;
using Moonlight.Client.App.PluginApi;

namespace ModerationPlugin.Client;

public class ModerationClientPlugin : MoonlightClientPlugin
{
    public ModerationClientPlugin(ILogger logger, PluginService pluginService) : base(logger, pluginService)
    {
        
    }

    public override Task OnLoaded()
    {
        Logger.LogInformation("Elo from moderation client plugin");
        
        PluginService.RegisterImplementation<ISidebarItemProvider, ModerationSidebarProvider>();
        PluginService.RegisterImplementation<IAppLoader, BanStateLoader>();
        PluginService.RegisterImplementation<IAppScreen, BanScreen>();
        
        return Task.CompletedTask;
    }

    public override Task OnAppBuilding(WebAssemblyHostBuilder builder)
    {
        builder.Services.AddSingleton<ModerationService>();
        
        return Task.CompletedTask;
    }
}