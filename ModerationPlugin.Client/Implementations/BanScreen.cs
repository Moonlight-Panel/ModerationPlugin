using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ModerationPlugin.Client.Services;
using ModerationPlugin.Client.UI.Components;
using MoonCore.Blazor.Helpers;
using Moonlight.Client.App.Interfaces;

namespace ModerationPlugin.Client.Implementations;

public class BanScreen : IAppScreen
{
    public int Priority => 1;
    
    public bool ShouldBeShown(IServiceProvider serviceProvider)
    {
        var moderationService = serviceProvider.GetRequiredService<ModerationService>();

        return moderationService.BanDetails != null;
    }

    public RenderFragment Render()
    {
        return ComponentHelper.FromType<BanScreenComponent>();
    }
}