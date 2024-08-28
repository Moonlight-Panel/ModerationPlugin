using ModerationPlugin.Shared.Http.Responses.UserBans;
using MoonCore.Attributes;

namespace ModerationPlugin.Client.Services;

[Singleton]
public class ModerationService
{
    public BanDetailsResponse? BanDetails { get; set; }
}