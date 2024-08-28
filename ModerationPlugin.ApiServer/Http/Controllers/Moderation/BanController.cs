using Microsoft.AspNetCore.Mvc;
using ModerationPlugin.ApiServer.Database.Entities;
using ModerationPlugin.Shared.Http.Responses.UserBans;
using MoonCore.Extended.Abstractions;
using MoonCore.Helpers;
using Moonlight.ApiServer.App.Attributes;
using Moonlight.ApiServer.App.Exceptions;
using Moonlight.ApiServer.App.Extensions;

namespace ModerationPlugin.ApiServer.Http.Controllers.Moderation;

[ApiController]
[Route("moderation/ban")]
public class BanController : Controller
{
    private readonly DatabaseRepository<UserBan> UserBanRepository;

    public BanController(DatabaseRepository<UserBan> userBanRepository)
    {
        UserBanRepository = userBanRepository;
    }

    [HttpGet("details")]
    [RequirePermission("meta.authenticated")]
    public async Task<ActionResult<BanDetailsResponse>> Details()
    {
        var user = HttpContext.GetCurrentUser();
        
        var bans = UserBanRepository
            .Get()
            .Where(x => x.UserId == user.Id)
            .ToArray();
        
        if(bans.Length == 0)
            throw new ApiException("No details on a ban available", statusCode: 400);
        
        var activeBan = bans.FirstOrDefault(x => DateTime.UtcNow < x.CreatedAt.AddDays(x.DurationDays));
        
        if(activeBan == null)
            throw new ApiException("No details on a ban available", statusCode: 400);

        return Ok(Mapper.Map<BanDetailsResponse>(activeBan));
    }
}