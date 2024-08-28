using Microsoft.Extensions.DependencyInjection;
using ModerationPlugin.Client.Services;
using ModerationPlugin.Shared.Http.Responses.UserBans;
using MoonCore.Helpers;
using Moonlight.Client.App.Interfaces;

namespace ModerationPlugin.Client.Implementations;

public class BanStateLoader : IAppLoader
{
    public int Priority => 0;
    
    public async Task Load(IServiceProvider serviceProvider)
    {
        var moderationService = serviceProvider.GetRequiredService<ModerationService>();
        var httpApiClient = serviceProvider.GetRequiredService<HttpApiClient>();

        moderationService.BanDetails = null;
        
        try
        {
            moderationService.BanDetails = await httpApiClient.GetJson<BanDetailsResponse>("moderation/ban/details");
        }
        catch (Exception)
        {
            // Ignored
        }
    }
}