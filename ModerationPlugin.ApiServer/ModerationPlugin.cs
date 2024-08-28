using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModerationPlugin.ApiServer.Database;
using ModerationPlugin.ApiServer.Http.Middleware;
using MoonCore.Extended.Helpers;
using Moonlight.ApiServer.App.PluginApi;

namespace ModerationPlugin.ApiServer;

public class ModerationPlugin : MoonlightPlugin
{
    public ModerationPlugin(ILogger logger, PluginService pluginService) : base(logger, pluginService)
    {
    }

    public override Task OnLoaded()
    {
        Logger.LogInformation("Elo from moderation api server plugin");
        
        return Task.CompletedTask;
    }

    public override Task OnAppBuilding(WebApplicationBuilder builder, DatabaseHelper databaseHelper)
    {
        builder.Services.AddDbContext<ModerationDataContext>();
        databaseHelper.AddDbContext<ModerationDataContext>();
        
        return Task.CompletedTask;
    }

    public override Task OnAppConfiguring(WebApplication app)
    {
        app.UseMiddleware<BanMiddleware>();
        
        return Task.CompletedTask;
    }
}