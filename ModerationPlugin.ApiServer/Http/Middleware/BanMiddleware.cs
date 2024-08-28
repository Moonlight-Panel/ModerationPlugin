using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ModerationPlugin.ApiServer.Database.Entities;
using MoonCore.Extended.Abstractions;
using Moonlight.ApiServer.App.Exceptions;
using Moonlight.ApiServer.App.Extensions;

namespace ModerationPlugin.ApiServer.Http.Middleware;

public class BanMiddleware
{
    private readonly RequestDelegate Next;

    public BanMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request!.Path!.Value!.StartsWith("/auth") &&
            !context.Request!.Path!.Value!.StartsWith("/moderation"))
        {
            if (context.GetCurrentUserNullable() != null)
            {
                var user = context.GetCurrentUser();
                var banRepo = context.RequestServices.GetRequiredService<DatabaseRepository<UserBan>>();

                var bans = banRepo
                    .Get()
                    .Where(x => x.UserId == user.Id)
                    .ToArray();

                if (bans.Length > 0)
                {
                    var activeBan = bans.FirstOrDefault(x => DateTime.UtcNow < x.CreatedAt.AddDays(x.DurationDays));

                    if (activeBan != null)
                    {
                        throw new ApiException($"Your account has been banned for {activeBan.DurationDays} days",
                            detail: activeBan.Reason, statusCode: 401);
                    }
                }
            }
        }
        
        await Next(context);
    }
}