using Microsoft.EntityFrameworkCore;
using ModerationPlugin.ApiServer.Database.Entities;
using Moonlight.ApiServer.App.Helpers.Database;

namespace ModerationPlugin.ApiServer.Database;

public class ModerationDataContext : DatabaseContext
{
    public override string Prefix => "Moderation";

    public DbSet<UserBan> UserBans { get; set; }
}