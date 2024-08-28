using Microsoft.AspNetCore.Mvc;
using ModerationPlugin.ApiServer.Database.Entities;
using ModerationPlugin.Shared.Http.Requests.UserBans;
using ModerationPlugin.Shared.Http.Responses.UserBans;
using MoonCore.Extended.Abstractions;
using Moonlight.ApiServer.App.Helpers;

namespace ModerationPlugin.ApiServer.Http.Controllers.Admin;

[ApiController]
[Route("admin/moderation/userbans")]
public class UserBansController : BaseCrudController<UserBan, DetailUserBanResponse, CreateUserBanRequest, DetailUserBanResponse, UpdateUserBanRequest, DetailUserBanResponse>
{
    public UserBansController(DatabaseRepository<UserBan> itemRepository) : base(itemRepository)
    {
        PermissionPrefix = "admin.moderation.userbans";
    }
}